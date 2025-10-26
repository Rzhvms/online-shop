namespace Logic.Models;

public record UserModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Уникальное имя пользователя (логин)
    /// </summary>
    public required string UserName { get; set; }
    
    /// <summary>
    /// Хэш пароля
    /// </summary>
    public required string Password { get; set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string? Surname { get; set; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// Электронная почта
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Телефон
    /// </summary>
    public string? Phone { get; set; }
        
    /// <summary>
    /// Подтверждена ли почта
    /// </summary>
    public bool EmailConfirmed { get; set; } = false;
    
    /// <summary>
    /// Подтверждён ли номер телефона
    /// </summary>
    public bool PhoneConfirmed { get; set; } = false;
    
    /// <summary>
    /// Аккаунт заблокирован?
    /// </summary>
    public bool IsBlocked { get; set; } = false;
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Дата последнего изменения
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}