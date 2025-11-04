namespace Infrastructure.Services.Auth.Jwt;

public record AccessTokenSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public long LifeTimeInSeconds { get; set; }
    public string PublicKey { get; set; }
    public string PrivateKey { get; set; }
}