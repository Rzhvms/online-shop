using Domain.User;

namespace Application.Ports.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями в хранилище данных
/// </summary>
public interface IAuthRepository
{
    /// <summary>
    /// Получает пользователя по адресу электронной почты.
    /// </summary>
    Task<UserModel?> GetUserByEmailAsync(string email);

    /// <summary>
    /// Получает пользователя по уникальному идентификатору.
    /// </summary>
    Task<UserModel?> GetUserByUserIdAsync(Guid userId);

    /// <summary>
    /// Создаёт нового пользователя в хранилище.
    /// </summary>
    Task CreateUserAsync(UserModel userModel);

    /// <summary>
    /// Обновляет данные существующего пользователя.
    /// </summary>
    Task UpdateUserAsync(UserModel userModel);

    /// <summary>
    /// Обновляем данный пользователя (для завершения регистрации)
    /// </summary>
    Task UpdateUserForFinalRegistrationAsync(Guid id, string name, string lastName, string gender, string phone);
}