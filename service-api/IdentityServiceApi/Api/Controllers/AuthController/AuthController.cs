using Api.Controllers.AuthController.Dto.Request;
using Api.Controllers.AuthController.Dto.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AuthController;

/// <summary>
/// Контроллер для авторизации и аутентификации пользователя
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<CreateRegisterUserResponse> RegisterUserAsync(CreateRegisterUserRequest request)
    {
        
    }

    /// <summary>
    /// Регистрация администратора
    /// </summary>
    [Authorize]
    [HttpPost("register-admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<CreateRegisterAdminResponse> RegisterAdminAsync(CreateRegisterAdminRequest request)
    {
        
    }

    /// <summary>
    /// Единая авторизация для пользователя и админа
    /// </summary>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<CreateLoginResponse> LoginAsync(CreateLoginRequest request)
    {
        
    }

    /// <summary>
    /// Выход из кабинета
    /// </summary>
    [Authorize]
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<CreateLogoutResponse> LogoutAsync(CreateLogoutRequest request)
    {
        
    }
}