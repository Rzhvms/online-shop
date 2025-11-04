using Application.Enums;
using Application.Ports.Repositories;
using Application.Ports.Services;
using Application.UseCases.Auth.Login.Request;
using Application.UseCases.Auth.Login.Response;
using Domain.User;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Auth.Login;

/// <inheritdoc />
public class LoginUseCase : ILoginUseCase
{
    private readonly ILogger<LoginUseCase> _logger;
    private readonly IAuthTokenService _authTokenService;
    private readonly IAuthRepository _authRepository;
    private readonly ICryptographyService _cryptographyService;

    public LoginUseCase(
        ILogger<LoginUseCase> logger,
        IAuthTokenService authTokenService,
        IAuthRepository authRepository,
        ICryptographyService cryptographyService)
    {
        _logger = logger;
        _authTokenService = authTokenService;
        _authRepository = authRepository;
        _cryptographyService = cryptographyService;
    }

    /// <summary>
    /// Основной метод выполнения use case — логин пользователя.
    /// </summary>
    public async Task<LoginResponse> ExecuteAsync(LoginRequest request)
    {
        // 1️⃣ Проверяем, существует ли пользователь
        var user = await _authRepository.GetUserByEmail(request.Email);
        if (user == null)
            return BuildErrorResponse(ErrorCodes.UserDoesNotExist);

        // 2️⃣ Проверяем корректность пароля
        if (!AreCredentialsValid(request.Password, user))
            return BuildErrorResponse(ErrorCodes.CredentialsAreNotValid);

        // 3️⃣ Генерируем новый refresh token
        user.RefreshToken = await CreateRefreshTokenAsync();

        // 4️⃣ Обновляем пользователя в базе
        await _authRepository.UpdateUser(user);

        // 5️⃣ Генерируем id и access токены
        var idToken = await _authTokenService.GenerateIdToken(user);
        var accessToken = await _authTokenService.GenerateAccessToken(user);

        // 6️⃣ Формируем успешный ответ
        return new LoginSuccessResponse
        {
            IdToken = idToken,
            AccessToken = accessToken,
            RefreshToken = user.RefreshToken.Value
        };
    }

    /// <summary>
    /// Проверяет соответствие пароля, введённого пользователем, хешу, сохранённому в БД.
    /// </summary>
    private bool AreCredentialsValid(string inputPassword, User user)
    {
        var computedHash = _cryptographyService.HashPassword(inputPassword, user.Salt);
        return computedHash == user.Password;
    }

    /// <summary>
    /// Создаёт новый refresh token с параметрами из AuthTokenService.
    /// </summary>
    private async Task<RefreshTokenEntity> CreateRefreshTokenAsync()
    {
        var lifetimeMinutes = await _authTokenService.GetRefreshTokenLifetimeInMinutes();
        return new RefreshTokenEntity
        {
            Value = await _authTokenService.GenerateRefreshToken(),
            Active = true,
            ExpirationDate = DateTime.UtcNow.AddMinutes(lifetimeMinutes)
        };
    }

    /// <summary>
    /// Универсальный метод для формирования ошибки с кодом и описанием.
    /// </summary>
    private static LoginErrorResponse BuildErrorResponse(ErrorCodes errorCode)
    {
        return new LoginErrorResponse
        {
            Message = Enum.GetName(typeof(ErrorCodes), errorCode),
            Code = ((int)errorCode).ToString()
        };
    }
}