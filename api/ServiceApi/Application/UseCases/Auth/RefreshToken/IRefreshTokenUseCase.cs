using Application.UseCases.Auth.RefreshToken.Request;
using Application.UseCases.Auth.RefreshToken.Response;

namespace Application.UseCases.Auth.RefreshToken;

/// <summary>
/// Юзкейс для обновления access-токена по действующему refresh-токену.
/// </summary>
public interface IRefreshTokenUseCase
{
    /// <summary>
    /// Проверяет refresh-токен и выдает новую пару токенов (access + refresh).
    /// </summary>
    Task<RefreshTokenResponse> ExecuteAsync(RefreshTokenRequest request);
}