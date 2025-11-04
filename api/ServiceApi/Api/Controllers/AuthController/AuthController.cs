using Application.UseCases.Auth.CreateUser;
using Application.UseCases.Auth.CreateUser.Request;
using Application.UseCases.Auth.CreateUser.Response;
using Application.UseCases.Auth.Login;
using Application.UseCases.Auth.Login.Request;
using Application.UseCases.Auth.Login.Response;
using Application.UseCases.Auth.RefreshToken;
using Application.UseCases.Auth.RefreshToken.Request;
using Application.UseCases.Auth.RefreshToken.Response;
using Application.UseCases.Auth.SignOut;
using Application.UseCases.Auth.SignOut.Request;
using Application.UseCases.Auth.SignOut.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AuthController;

/// <summary>
/// Контроллер для авторизации пользователя
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ILoginUseCase _loginUseCase;
    private readonly IRefreshTokenUseCase _refreshTokenUseCase;
    private readonly ISignOutUseCase _signOutUseCase;
    private readonly ICreateUserUseCase _createUserUseCase;

    public AuthController(
        ILoginUseCase loginUseCase,
        IRefreshTokenUseCase refreshTokenUseCase,
        ISignOutUseCase signOutUseCase,
        ICreateUserUseCase createUserUseCase)
    {
        _loginUseCase = loginUseCase;
        _refreshTokenUseCase = refreshTokenUseCase;
        _signOutUseCase = signOutUseCase;
        _createUserUseCase = createUserUseCase;
    }
    
    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        return await _loginUseCase.ExecuteAsync(request);
    }

    /// <summary>
    /// Обновление Refresh токена
    /// </summary>
    [AllowAnonymous]
    [HttpPost("refresh-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        return await _refreshTokenUseCase.ExecuteAsync(request);
    }

    /// <summary>
    /// Выход пользователя из ЛК, деактивация Refresh токена
    /// </summary>
    [Authorize]
    [HttpPost("sign-out")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<SignOutResponse> SignOutAsync(SignOutRequest request)
    {
        return await _signOutUseCase.ExecuteAsync(request);
    }

    /// <summary>
    /// Создание пользователя
    /// </summary>
    [AllowAnonymous]
    [HttpPost("create-user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
    {
        return await _createUserUseCase.ExecuteAsync(request);
    }
}