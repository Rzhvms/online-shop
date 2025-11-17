using System.Data;
using Application.Ports.Repositories;
using Dapper;
using Domain.User;
using Infrastructure.Repositories.Auth;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.User;

/// <inheritdoc />
internal class UserRepository : IUserRepository
{
    private readonly IDbConnection _dbConnection;
    private readonly ILogger<AuthRepository> _logger;
    
    public UserRepository(IDbConnection dbConnection, ILogger<AuthRepository> logger)
    {
        _dbConnection = dbConnection;
        _logger = logger;
    }
    
    /// <inheritdoc />
    public async Task<UserModel> GetUserInfoAsync(Guid id)
    {
        var sql = $@"
                SELECT ""{nameof(UserModel.Email)}"",
                       ""{nameof(UserModel.Phone)}"",
                       ""{nameof(UserModel.Name)}"",
                       ""{nameof(UserModel.LastName)}"",
                       ""{nameof(UserModel.CreateAt)}"",
                       ""{nameof(UserModel.UpdateAt)}""
                FROM ""{nameof(UserModel)}""
                WHERE ""{nameof(UserModel.Id)}"" = @Id";
        
        var response = await _dbConnection.QueryFirstAsync<UserModel>(sql, new { Id = id });
        return response;
    }

    /// <inheritdoc />
    public async Task<(Guid, DateTime)> UpdateUserInfoAsync(Guid id, string? phone, string? name, string? lastName)
    {
        var sql = "";
        var now = DateTime.UtcNow;
        
        if (phone != null)
        {
            sql = $@"
            UPDATE ""{nameof(UserModel)}""
            SET ""{nameof(UserModel.Phone)}"" = @Phone,
                ""{nameof(UserModel.UpdateAt)}"" = @Time
            WHERE ""{nameof(UserModel.Id)}"" = @Id";
        }
        
        if (name != null)
        { 
            sql = $@"
            UPDATE ""{nameof(UserModel)}""
            SET ""{nameof(UserModel.Name)}"" = @Name,
                ""{nameof(UserModel.UpdateAt)}"" = @Time
            WHERE ""{nameof(UserModel.Id)}"" = @Id";
        }
        
        if (lastName != null)
        {
            sql = $@"
            UPDATE ""{nameof(UserModel)}""
            SET ""{nameof(UserModel.LastName)}"" = @LastName,
                ""{nameof(UserModel.UpdateAt)}"" = @Time
            WHERE ""{nameof(UserModel.Id)}"" = @Id";
        }
        
        await _dbConnection.ExecuteAsync(sql, new { Id = id, Phone = phone, Name = name, LastName = lastName, Time = now });
        var response = (id, now);
        return response;
    }
    
    /// <inheritdoc />
    public async Task ChangeUserPasswordAsync(Guid id, string passwordHash, string salt)
    {
        var now = DateTime.UtcNow;
        var sql = $@"
            UPDATE ""{nameof(UserModel)}""
            SET ""{nameof(UserModel.Password)}"" = @PasswordHash,
                ""{nameof(UserModel.Salt)}"" = @Salt,
                ""{nameof(UserModel.UpdateAt)}"" = @Time
            WHERE ""{nameof(UserModel.Id)}"" = @Id";
        
        await _dbConnection.ExecuteAsync(sql, new { Id = id, PasswordHash = passwordHash, Salt = salt, Time = now });
    }
}