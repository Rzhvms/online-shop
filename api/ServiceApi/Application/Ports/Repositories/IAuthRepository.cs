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
    Task<UserDal?> GetUserByEmailAsync(string email);

    /// <summary>
    /// Получает пользователя по уникальному идентификатору.
    /// </summary>
    Task<UserDal?> GetUserByUserIdAsync(Guid userId);

    /// <summary>
    /// Создаёт нового пользователя в хранилище.
    /// </summary>
    Task CreateUserAsync(UserDal userDal);

    /// <summary>
    /// Обновляет данные существующего пользователя.
    /// </summary>
    Task UpdateUserAsync(UserDal userDal);
}