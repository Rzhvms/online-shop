namespace Infrastructure.Services.Auth.Jwt;

/// <summary>
/// Настройки Access Token
/// </summary>
public record AccessTokenSettings
{
    /// <summary>
    /// Издатель токена (issuer)
    /// </summary>
    public string Issuer { get; set; }
    
    /// <summary>
    /// Получатель токена (audience)
    /// </summary>
    public string Audience { get; set; }
    
    /// <summary>
    /// Время жизни токена в секундах
    /// </summary>
    public long LifeTimeInSeconds { get; set; }
    
    /// <summary>
    /// Публичный ключ для проверки подписи JWT
    /// </summary>
    public string PublicKey { get; set; }
    
    /// <summary>
    /// Приватный ключ для подписи JWT
    /// </summary>
    public string PrivateKey { get; set; }
}