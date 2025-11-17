using Domain.User;

namespace Application.Ports.Repositories;

/// <summary>
/// Репозиторий для управления базовой информацией о пользователе
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Получить базовую информацию о пользователе (UserModel)
    /// </summary>
    Task<UserModel> GetUserInfoAsync(Guid id);

    /// <summary>
    /// Изменить базовую информацию о пользователе (UserModel)
    /// </summary>
    Task<(Guid, DateTime)> UpdateUserInfoAsync(Guid id, string? phone, string? name, string? lastName);

    /// <summary>
    /// Изменить пароль
    /// </summary>
    Task ChangeUserPasswordAsync(Guid id, string passwordHash, string salt);
}