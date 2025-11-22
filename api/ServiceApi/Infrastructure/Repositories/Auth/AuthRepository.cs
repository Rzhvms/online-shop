using System.Data;
using Application.Ports.Repositories;
using Dapper;
using Domain.User;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Auth;

/// <inheritdoc />
public class AuthRepository : IAuthRepository
{
    private readonly IDbConnection _dbConnection;
    private readonly ILogger<AuthRepository> _logger;
    
    public AuthRepository(IDbConnection dbConnection, ILogger<AuthRepository> logger)
    {
        _dbConnection = dbConnection;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<UserModel?> GetUserByEmailAsync(string email)
    {
        var sql = $@"SELECT * FROM ""{nameof(UserModel)}"" 
                    WHERE ""{nameof(UserModel.Email)}"" = @Email";
        
        var user = await _dbConnection.QueryFirstOrDefaultAsync<UserModel>(sql, new { Email = email });
        
        if (user != null)
        {
            user.Claims = (await _dbConnection.QueryAsync<ClaimModel>(
                $@"SELECT * FROM ""{nameof(ClaimModel)}"" WHERE ""{nameof(ClaimModel.UserId)}"" = @UserId",
                new { UserId = user.Id })).ToList();

            user.RefreshToken = await _dbConnection.QueryFirstOrDefaultAsync<RefreshTokenModel>(
                $@"SELECT * FROM ""{nameof(RefreshTokenModel)}"" WHERE ""{nameof(RefreshTokenModel.UserId)}"" = @UserId",
                new { UserId = user.Id });
        }
        
        return user;
    }

    /// <inheritdoc />
    public async Task<UserModel?> GetUserByUserIdAsync(Guid id)
    {
        var sql = $@"SELECT * FROM ""{nameof(UserModel)}""
                    WHERE ""{nameof(UserModel.Id)}"" = @id";
        
        var user = await _dbConnection.QuerySingleOrDefaultAsync<UserModel>(sql, new { Id = id });
        
        if (user != null)
        {
            user.Claims = (await _dbConnection.QueryAsync<ClaimModel>(
                $@"SELECT * FROM ""{nameof(ClaimModel)}"" WHERE ""{nameof(ClaimModel.UserId)}"" = @UserId",
                new { UserId = user.Id })).ToList();

            user.RefreshToken = await _dbConnection.QueryFirstOrDefaultAsync<RefreshTokenModel>(
                $@"SELECT * FROM ""{nameof(RefreshTokenModel)}"" WHERE ""{nameof(RefreshTokenModel.UserId)}"" = @UserId",
                new { UserId = user.Id });
        }
        
        return user;
    }

    /// <inheritdoc />
    public async Task CreateUserAsync(UserModel userModel)
    {
        var sql = $@"INSERT INTO ""{nameof(UserModel)}"" 
                VALUES (@Id, @Email, @Phone, @Password, @Salt, @Name, @LastName, @CreateAt, @UpdateAt)";
        
        await _dbConnection.ExecuteAsync(sql, new
        {
            userModel.Id,
            userModel.Email,
            userModel.Phone,
            userModel.Password,
            userModel.Salt,
            userModel.Name,
            userModel.LastName,
            userModel.CreateAt,
            userModel.UpdateAt
        });
        
        if (userModel.Claims != null && userModel.Claims.Any())
        {
            foreach (var claim in userModel.Claims)
            {
                if (claim.Id == Guid.Empty)
                {
                    claim.Id = Guid.NewGuid();
                }
                
                claim.UserId = userModel.Id;
            }
            
            var claimsSql = $@"INSERT INTO ""{nameof(ClaimModel)}"" 
                               VALUES (@Id, @UserId, @Type, @Value)";
            await _dbConnection.ExecuteAsync(claimsSql, userModel.Claims);
        }

        if (userModel.RefreshToken != null)
        {
            if (userModel.RefreshToken.Id == Guid.Empty)
            {
                userModel.RefreshToken.Id = Guid.NewGuid();
            }
            
            userModel.RefreshToken.UserId = userModel.Id;
            
            var tokenSql = $@"INSERT INTO ""{nameof(RefreshTokenModel)}""
                              VALUES (@Id, @UserId, @Value, @Active, @ExpirationDate)";
            await _dbConnection.ExecuteAsync(tokenSql, userModel.RefreshToken);
        }
    }

    /// <inheritdoc />
    public async Task UpdateUserAsync(UserModel userModel)
    {
        var sql = $@"
            UPDATE ""{nameof(UserModel)}""
            SET ""{nameof(UserModel.Email)}"" = @Email,
                ""{nameof(UserModel.Phone)}"" = @Phone,
                ""{nameof(UserModel.Password)}"" = @Password,
                ""{nameof(UserModel.Salt)}"" = @Salt,
                ""{nameof(UserModel.Name)}"" = @Name,
                ""{nameof(UserModel.LastName)}"" = @LastName,
                ""{nameof(UserModel.UpdateAt)}"" = @UpdateAt
            WHERE ""{nameof(UserModel.Id)}"" = @Id";

        await _dbConnection.ExecuteAsync(sql, new
        {
            userModel.Email,
            userModel.Phone,
            userModel.Password,
            userModel.Salt,
            userModel.Name,
            userModel.LastName,
            UpdateAt = DateTime.UtcNow,
            userModel.Id
        });
        
        if (userModel.RefreshToken != null)
        {
            if (userModel.RefreshToken.Id == Guid.Empty)
            {
                userModel.RefreshToken.Id = Guid.NewGuid();
            }
            
            userModel.RefreshToken.UserId = userModel.Id;
            
            var tokenSql = $@"
                UPDATE ""{nameof(RefreshTokenModel)}""
                SET ""{nameof(RefreshTokenModel.Value)}"" = @Value,
                    ""{nameof(RefreshTokenModel.Active)}"" = @Active,
                    ""{nameof(RefreshTokenModel.ExpirationDate)}"" = @ExpirationDate
                WHERE ""{nameof(RefreshTokenModel.UserId)}"" = @UserId";

            await _dbConnection.ExecuteAsync(tokenSql, new
            {
                userModel.RefreshToken.Value,
                userModel.RefreshToken.Active,
                userModel.RefreshToken.ExpirationDate,
                UserId = userModel.Id
            });
        }

        if (userModel.Claims != null && userModel.Claims.Any())
        {
            foreach (var claim in userModel.Claims)
            {
                if (claim.Id == Guid.Empty)
                {
                    claim.Id = Guid.NewGuid();
                }
                
                claim.UserId = userModel.Id;
            }
            
            var deleteSql = $@"DELETE FROM ""{nameof(ClaimModel)}"" WHERE ""{nameof(ClaimModel.UserId)}"" = @UserId";
            await _dbConnection.ExecuteAsync(deleteSql, new { UserId = userModel.Id });

            var insertSql = $@"INSERT INTO ""{nameof(ClaimModel)}""
                               VALUES (@Id, @UserId, @Type, @Value)";
            await _dbConnection.ExecuteAsync(insertSql, userModel.Claims);
        }
    }

    /// <inheritdoc />
    public async Task UpdateUserForFinalRegistrationAsync(Guid id, string name, string lastName, string gender, string phone)
    {
        var sqlUser = $@"UPDATE ""{nameof(UserModel)}""
                    SET ""{nameof(UserModel.Name)}"" = @Name,
                        ""{nameof(UserModel.LastName)}"" = @LastName,
                        ""{nameof(UserModel.Phone)}"" = @Phone,
                        ""{nameof(UserModel.UpdateAt)}"" = @Now
                    WHERE ""{nameof(UserModel.Id)}"" = @Id";
        
        var sqlUserProfile = $@"UPDATE ""{nameof(UserProfileModel)}""
                    SET ""{nameof(UserProfileModel.Gender)}"" = @Gender
                    WHERE ""{nameof(UserProfileModel.UserId)}"" = @UserId";
        
        await _dbConnection.ExecuteAsync(sqlUser, new { Id = id, Name = name, LastName = lastName, Phone = phone, Now = DateTime.UtcNow });
        await _dbConnection.ExecuteAsync(sqlUserProfile, new { UserId = id, Gender = gender });
    }
}