using Application.Enums;
using Application.Ports.Repositories;
using Application.UseCases.Auth.SignOut.Request;
using Application.UseCases.Auth.SignOut.Response;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Auth.SignOut;

/// <inheritdoc />
public class SignOutUseCase : ISignOutUseCase
{
    private readonly ILogger<SignOutUseCase> _logger;
    private readonly IAuthRepository _authRepository;

    public SignOutUseCase(
        ILogger<SignOutUseCase> logger,
        IAuthRepository authRepository)
    {
        _logger = logger;
        _authRepository = authRepository;
    }

    /// <inheritdoc />
    public async Task<SignOutResponse> ExecuteAsync(SignOutRequest request)
    {
        // 1. Проверяем, что пользователь существует
        var user = await _authRepository.GetUserByUserId(request.UserId);
        if (user == null)
            return Error(ErrorCodes.UserDoesNotExist);

        // 2. Деактивируем refresh-токен
        if (user.RefreshToken != null)
        {
            user.RefreshToken.Active = false;
            await _authRepository.UpdateUser(user);
        }

        _logger.LogInformation("Пользователь {UserId} успешно вышел из системы.", user.Id);

        // 3. Возвращаем успешный ответ
        return new SignOutSuccessResponse
        {
            Message = $"User signed out at {DateTime.UtcNow:O} (UTC)."
        };
    }

    /// <summary>
    /// Формирует типовой ответ об ошибке.
    /// </summary>
    private static SignOutErrorResponse Error(ErrorCodes code)
    {
        return new SignOutErrorResponse
        {
            Message = Enum.GetName(typeof(ErrorCodes), code) ?? "Unknown error",
            Code = ((int)code).ToString()
        };
    }
}