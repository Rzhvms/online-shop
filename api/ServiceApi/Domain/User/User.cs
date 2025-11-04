using System.ComponentModel.DataAnnotations;

namespace Domain.User;

/// <summary>
/// Пользователь системы.
/// Содержит данные для аутентификации, персональные данные и права доступа.
/// </summary>
public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Электронная почта пользователя, используется для логина и уведомлений.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Номер телефона пользователя.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Хэш пароля пользователя.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Соль для хэширования пароля.
    /// </summary>
    public string Salt { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Список прав/роль пользователя.
    /// </summary>
    public IList<Claim>? Claims { get; set; }

    /// <summary>
    /// Связанный refresh-токен для обновления JWT.
    /// </summary>
    public RefreshTokenEntity? RefreshToken { get; set; }

    /// <summary>
    /// Дата создания пользователя.
    /// </summary>
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Дата последнего обновления данных пользователя.
    /// </summary>
    public DateTime? UpdateAt { get; set; }

    /// <summary>
    /// Конструктор по умолчанию. Инициализирует коллекции.
    /// </summary>
    public User()
    {
        Claims = new List<Claim>();
        RefreshToken = new RefreshTokenEntity();
    }
}