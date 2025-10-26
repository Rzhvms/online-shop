using Dal.DalEntities;
using Dal.Repositories.Interfaces;
using Logic.Managers.Interfaces;
using Logic.Models;
using Logic.Services.Interfaces;

namespace Logic.Managers;

public class AuthManager : IAuthManager
{
    private readonly IAuthRepository _authRepository;
    private readonly IHashPasswordService _hashPasswordService;
    
    public AuthManager(
        IAuthRepository authRepository,
        IHashPasswordService hashPasswordService)
    {
        _authRepository = authRepository;
        _hashPasswordService = hashPasswordService;
    }
    
    public async Task CreateUserAsync(UserModel userModel)
    {
        var passwordHash = await _hashPasswordService.HashPassword(userModel.Password);
        var userDal = new UserDal
        {
            UserName = userModel.UserName,
            Name = userModel.Name,
            Surname = userModel.Surname,
            MiddleName = userModel.MiddleName,
            PasswordHash = passwordHash,
            Phone = userModel.Phone,
            Email = userModel.Email,
        };
        
        await _authRepository.CreateUserAsync(userDal);
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        
    }
}