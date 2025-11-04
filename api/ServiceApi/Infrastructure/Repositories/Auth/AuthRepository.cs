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
    public async Task<UserDal?> GetUserByEmailAsync(string email)
    {
        var sql = $@"SELECT * FROM ""{nameof(UserDal)}"" 
                    WHERE ""{nameof(UserDal.Email)}"" = @Email";
        
        var user = await _dbConnection.QueryFirstOrDefaultAsync<UserDal>(sql, new { Email = email });
        
        if (user != null)
        {
            user.Claims = (await _dbConnection.QueryAsync<ClaimDal>(
                $@"SELECT * FROM ""{nameof(ClaimDal)}"" WHERE ""{nameof(ClaimDal.UserId)}"" = @UserId",
                new { UserId = user.Id })).ToList();

            user.RefreshToken = await _dbConnection.QueryFirstOrDefaultAsync<RefreshTokenDal>(
                $@"SELECT * FROM ""{nameof(RefreshTokenDal)}"" WHERE ""{nameof(RefreshTokenDal.UserId)}"" = @UserId",
                new { UserId = user.Id });
        }
        
        return user;
    }

    /// <inheritdoc />
    public async Task<UserDal?> GetUserByUserIdAsync(Guid id)
    {
        var sql = $@"SELECT * FROM ""{nameof(UserDal)}""
                    WHERE ""{nameof(UserDal.Id)}"" = @id";
        
        var user = await _dbConnection.QuerySingleOrDefaultAsync<UserDal>(sql, new { Id = id });
        
        if (user != null)
        {
            user.Claims = (await _dbConnection.QueryAsync<ClaimDal>(
                $@"SELECT * FROM ""{nameof(ClaimDal)}"" WHERE ""{nameof(ClaimDal.UserId)}"" = @UserId",
                new { UserId = user.Id })).ToList();

            user.RefreshToken = await _dbConnection.QueryFirstOrDefaultAsync<RefreshTokenDal>(
                $@"SELECT * FROM ""{nameof(RefreshTokenDal)}"" WHERE ""{nameof(RefreshTokenDal.UserId)}"" = @UserId",
                new { UserId = user.Id });
        }
        
        return user;
    }

    /// <inheritdoc />
    public async Task CreateUserAsync(UserDal userDal)
    {
        var sql = $@"INSERT INTO ""{nameof(UserDal)}"" 
                VALUES (@Id, @Email, @Phone, @Password, @Salt, @Name, @LastName, @CreateAt, @UpdateAt)";
        
        await _dbConnection.ExecuteAsync(sql, new
        {
            userDal.Id,
            userDal.Email,
            userDal.Phone,
            userDal.Password,
            userDal.Salt,
            userDal.Name,
            userDal.LastName,
            userDal.CreateAt,
            userDal.UpdateAt
        });
        
        if (userDal.Claims != null && userDal.Claims.Any())
        {
            foreach (var claim in userDal.Claims)
            {
                if (claim.Id == Guid.Empty)
                {
                    claim.Id = Guid.NewGuid();
                }
                
                claim.UserId = userDal.Id;
            }
            
            var claimsSql = $@"INSERT INTO ""{nameof(ClaimDal)}"" 
                               VALUES (@Id, @UserId, @Type, @Value)";
            await _dbConnection.ExecuteAsync(claimsSql, userDal.Claims);
        }

        if (userDal.RefreshToken != null)
        {
            if (userDal.RefreshToken.Id == Guid.Empty)
            {
                userDal.RefreshToken.Id = Guid.NewGuid();
            }
            
            userDal.RefreshToken.UserId = userDal.Id;
            
            var tokenSql = $@"INSERT INTO ""{nameof(RefreshTokenDal)}""
                              VALUES (@Id, @UserId, @Value, @Active, @ExpirationDate)";
            await _dbConnection.ExecuteAsync(tokenSql, userDal.RefreshToken);
        }
    }

    /// <inheritdoc />
    public async Task UpdateUserAsync(UserDal userDal)
    {
        var sql = $@"
            UPDATE ""{nameof(UserDal)}""
            SET ""{nameof(UserDal.Email)}"" = @Email,
                ""{nameof(UserDal.Phone)}"" = @Phone,
                ""{nameof(UserDal.Password)}"" = @Password,
                ""{nameof(UserDal.Salt)}"" = @Salt,
                ""{nameof(UserDal.Name)}"" = @Name,
                ""{nameof(UserDal.LastName)}"" = @LastName,
                ""{nameof(UserDal.UpdateAt)}"" = @UpdateAt
            WHERE ""{nameof(UserDal.Id)}"" = @Id";

        await _dbConnection.ExecuteAsync(sql, new
        {
            userDal.Email,
            userDal.Phone,
            userDal.Password,
            userDal.Salt,
            userDal.Name,
            userDal.LastName,
            UpdateAt = DateTime.UtcNow,
            userDal.Id
        });
        
        if (userDal.RefreshToken != null)
        {
            if (userDal.RefreshToken.Id == Guid.Empty)
            {
                userDal.RefreshToken.Id = Guid.NewGuid();
            }
            
            userDal.RefreshToken.UserId = userDal.Id;
            
            var tokenSql = $@"
                UPDATE ""{nameof(RefreshTokenDal)}""
                SET ""{nameof(RefreshTokenDal.Value)}"" = @Value,
                    ""{nameof(RefreshTokenDal.Active)}"" = @Active,
                    ""{nameof(RefreshTokenDal.ExpirationDate)}"" = @ExpirationDate
                WHERE ""{nameof(RefreshTokenDal.UserId)}"" = @UserId";

            await _dbConnection.ExecuteAsync(tokenSql, new
            {
                userDal.RefreshToken.Value,
                userDal.RefreshToken.Active,
                userDal.RefreshToken.ExpirationDate,
                UserId = userDal.Id
            });
        }

        if (userDal.Claims != null && userDal.Claims.Any())
        {
            foreach (var claim in userDal.Claims)
            {
                if (claim.Id == Guid.Empty)
                {
                    claim.Id = Guid.NewGuid();
                }
                
                claim.UserId = userDal.Id;
            }
            
            var deleteSql = $@"DELETE FROM ""{nameof(ClaimDal)}"" WHERE ""{nameof(ClaimDal.UserId)}"" = @UserId";
            await _dbConnection.ExecuteAsync(deleteSql, new { UserId = userDal.Id });

            var insertSql = $@"INSERT INTO ""{nameof(ClaimDal)}""
                               VALUES (@Id, @UserId, @Type, @Value)";
            await _dbConnection.ExecuteAsync(insertSql, userDal.Claims);
        }
    }
}