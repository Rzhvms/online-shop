using System.ComponentModel.DataAnnotations;
using Dal.DalEntities.Enums;

namespace Dal.DalEntities;

/// <summary>
/// Dal сущность пользователя
/// </summary>
public record UserDal
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Логин пользователя
    /// </summary>
    [Required]
    public required string UserName { get; set; }
    
    /// <summary>
    /// Хэш пароля
    /// </summary>
    [Required]
    public required string PasswordHash { get; set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string? Surname { get; set; }
    
    /// <summary>
    /// Отчество пользователя
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    [EmailAddress]
    public string? Email { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    [RegularExpression(@"^(\+7|8)?[\s\-]?\(?[0-9]{3}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$")]
    public string? Phone { get; set; }
    
    /// <summary>
    /// Роль пользователя
    /// </summary>
    [Required]
    public required UserRoleEnum Role { get; set; }
        
    /// <summary>
    /// Подтверждена ли почта
    /// </summary>
    public bool EmailConfirmed { get; set; } = false;
    
    /// <summary>
    /// Подтвержден ли номер телефона
    /// </summary>
    public bool PhoneConfirmed { get; set; } = false;
    
    /// <summary>
    /// Дата создания пользователя
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Дата изменения аккаунта
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}