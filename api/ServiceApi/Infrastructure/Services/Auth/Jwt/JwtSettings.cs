namespace Infrastructure.Services.Auth.Jwt;

public record JwtSettings
{
    public AccessTokenSettings AccessTokenSettings { get; set; }
    public RefreshTokenSettings RefreshTokenSettings { get; set; }
}