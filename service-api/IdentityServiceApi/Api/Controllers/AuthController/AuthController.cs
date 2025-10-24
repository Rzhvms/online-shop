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
    public async Task RegisterUserAsync()
    {
        
    }

    /// <summary>
    /// Регистрация администратора
    /// </summary>
    public async Task RegisterAdminAsync()
    {
        
    }

    /// <summary>
    /// Единая авторизация для пользователя и админа
    /// </summary>
    public async Task LoginAsync()
    {
        
    }

    /// <summary>
    /// Выход из кабинета
    /// </summary>
    public async Task LogoutAsync()
    {
        
    }
}