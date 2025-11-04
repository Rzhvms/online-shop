namespace Infrastructure.Services.Auth.Jwt;

/// <summary>
/// Настройки Refresh Token
/// </summary>
public record RefreshTokenSettings
{
    /// <summary>
    /// Длина сгенерированного токена
    /// </summary>
    public int Length { get; set; }
    
    /// <summary>
    /// Время жизни токена в минутах
    /// </summary>
    public int LifeTimeInMinutes { get; set; }
}