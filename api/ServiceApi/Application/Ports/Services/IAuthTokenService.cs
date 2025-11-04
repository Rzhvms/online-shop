using Domain.User;

namespace Application.Ports.Services;

/// <summary>
/// Сервис для работы с токенами (JWT, Refresh Token)
/// </summary>
public interface IAuthTokenService
{
    /// <summary>
    /// Генерация ID токена для пользователя
    /// </summary>
    Task<string> GenerateIdToken(UserDal userDal);
    
    /// <summary>
    /// Генерация Access Token для пользователя
    /// </summary>
    Task<string> GenerateAccessToken(UserDal userDal);
    
    /// <summary>
    /// Генерация нового Refresh Token
    /// </summary>
    Task<string> GenerateRefreshToken();
    
    /// <summary>
    /// Получение идентификатора пользователя из Access Token
    /// </summary>
    Task<Guid> GetUserIdFromToken(string token);
    
    /// <summary>
    /// Получение времени жизни Refresh Token в минутах
    /// </summary>
    Task<int> GetRefreshTokenLifetimeInMinutes();
    
    /// <summary>
    /// Проверка валидности токена
    /// </summary>
    Task<bool> IsTokenValid(string accessToken, bool validateLifeTime);
}