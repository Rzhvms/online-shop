namespace Domain.User;

/// <summary>
/// Refresh-токен для пользователя.
/// Используется для получения новой пары JWT после истечения старого токена.
/// </summary>
public class RefreshTokenEntity
{
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