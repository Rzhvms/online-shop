namespace Domain.User;

/// <summary>
/// Представляет право или роль пользователя.
/// Используется для авторизации и контроля доступа.
/// </summary>
public class ClaimModel
{
    /// <summary>
    /// Идентификатор права
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Тип права/роли
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Значение права/роли
    /// </summary>
    public string Value { get; set; }
}