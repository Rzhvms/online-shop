namespace Dal.Repositories.Interfaces;

/// <summary>
/// Репозиторий для авторизации пользователя
/// </summary>
public interface IAuthRepository
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