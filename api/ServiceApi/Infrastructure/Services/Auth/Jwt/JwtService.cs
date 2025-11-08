using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Application.Exceptions;
using Application.Ports.Services;
using Domain.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services.Auth.Jwt;

/// <inheritdoc />
public class JwtService : IAuthTokenService
{
    private readonly IOptions<JwtSettings> _settings;
    private readonly RsaSecurityKey _rsaSecurityKey;

    public JwtService(IOptions<JwtSettings> settings, RsaSecurityKey rsaSecurityKey)
    {
        _settings = settings;
        _rsaSecurityKey = rsaSecurityKey;
    }

    /// <inheritdoc />
    public Task<string> GenerateAccessToken(UserModel userModel)
    {
        var signingCredentials = new SigningCredentials(
            key: _rsaSecurityKey,
            algorithm: SecurityAlgorithms.RsaSha256
        );

        var claimsIdentity = new ClaimsIdentity();

        // Access Token must only carry the user Id
        claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()));

        // Add scope claim, which contains an array of scopes
        var scope = userModel.Claims.SingleOrDefault(c => c.Type == "scope");
        if (scope != null)
            claimsIdentity.AddClaim(new Claim("scope", string.Join(" ", scope.Value)));

        var jwtHandler = new JwtSecurityTokenHandler();

        var jwt = jwtHandler.CreateJwtSecurityToken(
            issuer: _settings.Value.AccessTokenSettings.Issuer,
            audience: _settings.Value.AccessTokenSettings.Audience,
            subject: claimsIdentity,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddSeconds(_settings.Value.AccessTokenSettings.LifeTimeInSeconds),
            issuedAt: DateTime.UtcNow,
            signingCredentials: signingCredentials);

        var serializedJwt = jwtHandler.WriteToken(jwt);

        return Task.FromResult(serializedJwt);
    }

    /// <inheritdoc />
    public Task<string> GenerateIdToken(UserModel userModel)
    {
        var signingCredentials = new SigningCredentials(
            key: _rsaSecurityKey,
            algorithm: SecurityAlgorithms.RsaSha256
        );

        var claimsIdentity = new ClaimsIdentity();

        claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()));
        claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Name, userModel.Name));
        claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Email, userModel.Email));
        claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.GivenName, userModel.Name));
        claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Surname, userModel.LastName));

        // Add custom claims if any
        foreach (var c in userModel.Claims ?? System.Linq.Enumerable.Empty<Domain.User.ClaimModel>())
        {
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(c.Type, c.Value));
        }

        var jwtHandler = new JwtSecurityTokenHandler();

        var jwt = jwtHandler.CreateJwtSecurityToken(
            issuer: _settings.Value.AccessTokenSettings.Issuer,
            audience: _settings.Value.AccessTokenSettings.Audience,
            subject: claimsIdentity,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddSeconds(_settings.Value.AccessTokenSettings.LifeTimeInSeconds),
            issuedAt: DateTime.UtcNow,
            signingCredentials: signingCredentials);

        var serializedJwt = jwtHandler.WriteToken(jwt);

        return Task.FromResult(serializedJwt);
    }

    /// <inheritdoc />
    public Task<string> GenerateRefreshToken()
    {
        var size = _settings.Value.RefreshTokenSettings.Length;
        var buffer = new byte[size];
        using var rng = new RNGCryptoServiceProvider();
        rng.GetBytes(buffer);
        return Task.FromResult(Convert.ToBase64String(buffer));
    }

    /// <inheritdoc />
    public Task<int> GetRefreshTokenLifetimeInMinutes()
    {
        return Task.FromResult(_settings.Value.RefreshTokenSettings.LifeTimeInMinutes);
    }

    /// <inheritdoc />
    public Task<Guid> GetUserIdFromToken(string token)
    {
        try
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime =
                    false, // we may be trying to validate an expired token so it makes no sense checking for it's lifetime.
                ValidateIssuerSigningKey = true,
                ValidIssuer = _settings.Value.AccessTokenSettings.Issuer,
                ValidAudience = _settings.Value.AccessTokenSettings.Audience,
                IssuerSigningKey = _rsaSecurityKey,
                ClockSkew = TimeSpan.FromMinutes(0)
            };

            var jwtHandler = new JwtSecurityTokenHandler();
            var claims = jwtHandler.ValidateToken(token, tokenValidationParameters, out _);
            var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier).Value);

            return Task.FromResult(userId);
        }
        catch (Exception ex)
        {
            throw new InvalidTokenException(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public Task<bool> IsTokenValid(string token, bool validateLifeTime)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = validateLifeTime,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _settings.Value.AccessTokenSettings.Issuer,
            ValidAudience = _settings.Value.AccessTokenSettings.Audience,
            IssuerSigningKey = _rsaSecurityKey,
            ClockSkew = TimeSpan.FromMinutes(0)
        };

        var jwtHandler = new JwtSecurityTokenHandler();
        try
        {
            jwtHandler.ValidateToken(token, tokenValidationParameters, out _);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }
}