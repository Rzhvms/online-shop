using Logic.Models;

namespace Logic.Managers.Interfaces;

public interface IAuthManager
{
    Task CreateUserAsync(UserModel userModel);

    Task<string> LoginAsync(string email, string password);
}