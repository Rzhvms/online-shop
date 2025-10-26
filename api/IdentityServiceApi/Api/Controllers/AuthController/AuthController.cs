using Api.Controllers.AuthController.Dto.Request;
using Api.Controllers.AuthController.Dto.Response;
using Api.UseCases.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AuthController;

/// <summary>
/// Контроллер, отвечающий за регистрацию, авторизацию, аутентификацию и управление паролями.
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthUseCase _authUseCase;
    
    public AuthController(IAuthUseCase authUseCase)
    {
        _authUseCase = authUseCase;
    }

    /// <summary>
    /// Регистрация нового пользователя
    /// </summary>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateUserAsync(CreateUserRequest request)
    {
        await _authUseCase.CreateUserAsync(request);
        return Ok("Успешная регистрация");
    }

    /// <summary>
    /// Авторизация пользователя и выдача JWT и Refresh токенов
    /// </summary>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<LoginUserResponse>> LoginAsync(LoginUserRequest request)
    {
        var response = await _authUseCase.LoginAsync(request);
        return Ok(response);
    }
    

    /// <summary>
    /// Изменение пароля пользователя
    /// </summary>
    [Authorize]
    [HttpPost("change-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdatePasswordAsync()
    {
        
    }

    /// <summary>
    /// Процесс восстановления пароля по Email
    /// </summary>
    [HttpPost("forgot-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateForgotPasswordAsync(ForgotPasswordRequest request)
    {
        
    }
}
