namespace Domain.User;

/// <summary>
/// Refresh-токен для пользователя.
/// Используется для получения новой пары JWT после истечения старого токена.
/// </summary>
public class RefreshTokenModel
{
    /// <summary>
    /// Идентификатор токена
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Значение токена.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Активность токена. Если false, токен аннулирован.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Дата истечения срока действия токена.
    /// </summary>
    public DateTime ExpirationDate { get; set; }
}