using AutoMapper;
using Dal.DalEntities;
using Dal.Repositories.Interfaces;
using Logic.Managers.Interfaces;
using Logic.Models;
using Logic.Services.Interfaces;

namespace Logic.Services;

/// <inheritdoc />
public class AuthService : IAuthService
{
    private readonly IAuthManager _authManager;
    
    public AuthService(IAuthManager authManager)
    {
        _authManager = authManager;
    }

    /// <inheritdoc />
    public async Task CreateUserAsync(UserModel userModel)
    {
        await _authManager.CreateUserAsync(userModel);
    }

    /// <inheritdoc />
    public async Task<string> LoginAsync(string email, string password)
    {
        
    }

    /// <inheritdoc />
    public async Task UpdatePasswordAsync(Guid userId, string newPassword)
    {
        
    }

    /// <inheritdoc />
    public async Task UpdateForgotPasswordAsync(string email)
    {
        
    }
}
