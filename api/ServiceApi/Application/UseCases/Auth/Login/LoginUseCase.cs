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
        var user = await _authRepository.GetUserByEmailAsync(request.Email);

        if (user == null)
        {
            return BuildErrorResponse(ErrorCodes.UserDoesNotExist);
        }

        if (!AreCredentialsValid(request.Password, user))
        {
            return BuildErrorResponse(ErrorCodes.CredentialsAreNotValid);
        }

        user.RefreshToken = await CreateRefreshTokenAsync();

        await _authRepository.UpdateUserAsync(user);

        var idToken = await _authTokenService.GenerateIdToken(user);
        var accessToken = await _authTokenService.GenerateAccessToken(user);

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
    private bool AreCredentialsValid(string inputPassword, UserDal userDal)
    {
        var computedHash = _cryptographyService.HashPassword(inputPassword, userDal.Salt);
        return computedHash == userDal.Password;
    }

    /// <summary>
    /// Создаёт новый refresh token с параметрами из AuthTokenService.
    /// </summary>
    private async Task<RefreshTokenDal> CreateRefreshTokenAsync()
    {
        var lifetimeMinutes = await _authTokenService.GetRefreshTokenLifetimeInMinutes();
        return new RefreshTokenDal
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