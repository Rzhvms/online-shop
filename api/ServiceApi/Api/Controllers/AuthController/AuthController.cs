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
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        return await _loginUseCase.ExecuteAsync(request);
    }

    [AllowAnonymous]
    [HttpPost("refreshToken")]
    public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        return await _refreshTokenUseCase.ExecuteAsync(request);
    }

    [AllowAnonymous]
    [HttpPost("signOut")]
    public async Task<SignOutResponse> SignOutAsync(SignOutRequest request)
    {
        return await _signOutUseCase.ExecuteAsync(request);
    }

    [AllowAnonymous]
    [HttpPost("createUser")]
    public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
    {
        return await _createUserUseCase.ExecuteAsync(request);
    }
}