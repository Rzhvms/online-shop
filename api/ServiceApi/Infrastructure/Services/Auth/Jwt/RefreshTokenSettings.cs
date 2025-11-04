namespace Infrastructure.Services.Auth.Jwt;

public record RefreshTokenSettings
{
    public int Length { get; set; }
    public int LifeTimeInMinutes { get; set; }
}