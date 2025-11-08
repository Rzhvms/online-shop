namespace Domain.User;

/// <summary>
/// Модель профиля пользователя
/// </summary>
public class UserProfileModel
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя из UserModel
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Путь до аватара пользователя
    /// </summary>
    public string? AvatarUrl { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; set; }
    
    /// <summary>
    /// Пол пользователя
    /// </summary>
    public string? Gender { get; set; }
    
    /// <summary>
    /// Статус / информация о себе
    /// </summary>
    public string? About { get; set; }
}