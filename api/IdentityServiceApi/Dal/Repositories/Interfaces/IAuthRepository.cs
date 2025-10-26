using Dal.DalEntities;

namespace Dal.Repositories.Interfaces;

/// <summary>
/// Репозиторий для авторизации пользователя
/// </summary>
public interface IAuthRepository
{
    /// <summary>
    /// Регистрация нового пользователя
    /// </summary>
    Task CreateUserAsync(UserDal user);
    
    /// <summary>
    /// Изменение пароля
    /// </summary>
    Task UpdatePasswordAsync(Guid userId, string newPassword);

    /// <summary>
    /// Процесс восстановления пароля по Email
    /// </summary>
    Task UpdateForgotPasswordAsync(string email);
}