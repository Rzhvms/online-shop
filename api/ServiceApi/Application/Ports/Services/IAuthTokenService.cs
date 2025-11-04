using Domain.User;

namespace Application.Ports.Services;

public interface IAuthTokenService
{
    Task<string> GenerateIdToken(User user);
    Task<string> GenerateAccessToken(User user);
    Task<string> GenerateRefreshToken();
    Task<Guid> GetUserIdFromToken(string token);
    Task<int> GetRefreshTokenLifetimeInMinutes();
    Task<bool> IsTokenValid(string accessToken, bool validateLifeTime);
}