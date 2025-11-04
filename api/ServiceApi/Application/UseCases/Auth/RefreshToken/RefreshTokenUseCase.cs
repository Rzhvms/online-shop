using Application.Enums;
using Application.Ports.Repositories;
using Application.Ports.Services;
using Application.UseCases.Auth.RefreshToken.Request;
using Application.UseCases.Auth.RefreshToken.Response;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Auth.RefreshToken;

/// <inheritdoc />
public class RefreshTokenUseCase : IRefreshTokenUseCase
{
    private readonly ILogger<RefreshTokenUseCase> _logger;
    private readonly IAuthTokenService _authTokenService;
    private readonly IAuthRepository _authRepository;

    public RefreshTokenUseCase(
        ILogger<RefreshTokenUseCase> logger,
        IAuthTokenService authTokenService,
        IAuthRepository authRepository)
    {
        _logger = logger;
        _authTokenService = authTokenService;
        _authRepository = authRepository;
    }

    /// <inheritdoc />
    public async Task<RefreshTokenResponse> ExecuteAsync(RefreshTokenRequest request)
    {
        // 1. Проверяем валидность access-токена
        var isValid = await _authTokenService.IsTokenValid(request.AccessToken, false);
        if (!isValid)
        {
            return Error(ErrorCodes.AccessTokenIsNotValid);
        }

        // 2. Получаем пользователя из токена
        var userId = await _authTokenService.GetUserIdFromToken(request.AccessToken);
        var user = await _authRepository.GetUserByUserId(userId);

        if (user == null)
            return Error(ErrorCodes.UserDoesNotExist);

        // 3. Проверяем refresh-токен
        var token = user.RefreshToken;
        if (!token.Active)
            return Error(ErrorCodes.RefreshTokenIsNotActive);

        if (token.ExpirationDate < DateTime.UtcNow)
            return Error(ErrorCodes.RefreshTokenHasExpired);

        if (token.Value != request.RefreshToken)
            return Error(ErrorCodes.RefreshTokenIsNotCorrect);

        // 4. Генерируем новые токены
        var newAccessToken = await _authTokenService.GenerateAccessToken(user);
        var newRefreshTokenValue = await _authTokenService.GenerateRefreshToken();

        user.RefreshToken.Value = newRefreshTokenValue;
        user.RefreshToken.Active = true;
        user.RefreshToken.ExpirationDate = DateTime.UtcNow.AddMinutes(
            await _authTokenService.GetRefreshTokenLifetimeInMinutes()
        );

        await _authRepository.UpdateUser(user);

        _logger.LogInformation("Refresh-токен обновлён для пользователя {UserId}", user.Id);

        // 5. Возвращаем успешный ответ
        return new RefreshTokenSuccessResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshTokenValue,
            RefreshTokenExpirationDate = user.RefreshToken.ExpirationDate
        };
    }

    /// <summary>
    /// Формирует стандартный ответ об ошибке по коду.
    /// </summary>
    private static RefreshTokenErrorResponse Error(ErrorCodes code)
    {
        return new RefreshTokenErrorResponse
        {
            Message = Enum.GetName(typeof(ErrorCodes), code) ?? "Ошибка",
            Code = ((int)code).ToString()
        };
    }
}