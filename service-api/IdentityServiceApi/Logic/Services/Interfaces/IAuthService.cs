namespace Logic.Services.Interfaces;

/// <summary>
/// Сервис для авторизации и аутентификации пользователя
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    Task RegisterUserAsync();
    
    /// <summary>
    /// Регистрация администратора
    /// </summary>
    Task RegisterAdminAsync();
    
    /// <summary>
    /// Единая авторизация для пользователя и админа
    /// </summary>
    Task LoginAsync();
    
    /// <summary>
    /// Выход из кабинета
    /// </summary>
    Task LogoutAsync();
}