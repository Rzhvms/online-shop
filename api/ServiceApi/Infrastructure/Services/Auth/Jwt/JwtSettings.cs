namespace Infrastructure.Services.Auth.Jwt;

/// <summary>
/// Настройки JWT для приложения
/// </summary>
public record JwtSettings
{
    /// <summary>
    /// Настройки Access Token
    /// </summary>
    public AccessTokenSettings AccessTokenSettings { get; set; }
    
    /// <summary>
    /// Настройки Refresh Token
    /// </summary>
    public RefreshTokenSettings RefreshTokenSettings { get; set; }
}