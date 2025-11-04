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
    Task<User?> GetUserByEmail(string email);

    /// <summary>
    /// Получает пользователя по уникальному идентификатору.
    /// </summary>
    Task<User?> GetUserByUserId(Guid userId);

    /// <summary>
    /// Создаёт нового пользователя в хранилище.
    /// </summary>
    Task CreateUser(User user);

    /// <summary>
    /// Обновляет данные существующего пользователя.
    /// </summary>
    Task UpdateUser(User user);
}