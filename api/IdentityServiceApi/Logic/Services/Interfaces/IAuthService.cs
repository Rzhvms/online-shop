using Logic.Models;

namespace Logic.Services.Interfaces;

/// <summary>
/// Сервис для реализации логики аутентификации, авторизации и управления сессиями
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Регистрация нового пользователя
    /// </summary>
    Task CreateUserAsync(UserModel userModel);

    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    Task<string> LoginAsync(string email, string password);
    
    /// <summary>
    /// Изменение пароля
    /// </summary>
    Task UpdatePasswordAsync(Guid userId, string newPassword);

    /// <summary>
    /// Процесс восстановления пароля по Email
    /// </summary>
    Task UpdateForgotPasswordAsync(string email);
}