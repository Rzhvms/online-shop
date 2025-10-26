
using System.Data;
using Dal.DalEntities;
using Dal.Repositories.Interfaces;
using Dapper;

namespace Dal.Repositories;

/// <inheritdoc />
public class AuthRepository : IAuthRepository
{
    private readonly IDbConnection _dbConnection;
    public AuthRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    /// <inheritdoc />
    public async Task CreateUserAsync(UserDal user)
    {
        var userId = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        
        var sql = $@"INSERT INTO {nameof(UserDal)} (
                        {nameof(UserDal.Id)},
                        {nameof(UserDal.UserName)},
                        {nameof(UserDal.PasswordHash)},
                        {nameof(UserDal.Email)},
                        {nameof(UserDal.CreatedAt)})
                    VALUES (@Id, @UserName, @PasswordHash, @Email, @CreatedAt)";
        
        await _dbConnection.ExecuteAsync(sql, new
        {
            Id = userId,
            user.UserName,
            user.PasswordHash,
            user.Email,
            CreatedAt = createdAt
        });
    }

    /// <inheritdoc />
    public async Task UpdatePasswordAsync(Guid userId, string newPassword)
    {
        var sql = $@"UPDATE {nameof(UserDal)}
                    SET {nameof(UserDal.PasswordHash)} = @newPassword
                    WHERE {nameof(UserDal.Id)} = @userId";

        await _dbConnection.ExecuteAsync(sql, new
        {
            Id = userId,
            PasswordHash = newPassword
        });
    }

    /// <inheritdoc />
    public async Task UpdateForgotPasswordAsync(string email)
    {
        
    }
}