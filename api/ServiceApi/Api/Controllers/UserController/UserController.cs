using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.UserController;

/// <summary>
/// Контроллер по управлению пользовательскими данными
/// </summary>
[Authorize]
[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    public UserController()
    {

    }

    /// <summary>
    /// Получить базовую информацию о пользователе (UserModel)
    /// </summary>
    [HttpGet("me")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task GetUserInfoAsync()
    {

    }

    /// <summary>
    /// Изменить базовую информацию о пользователе (UserModel)
    /// </summary>
    [HttpPut("me")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task UpdateUserInfoAsync()
    {
        
    }

    /// <summary>
    /// Изменить пароль
    /// </summary>
    [HttpPut("me/password")] 
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task ChangeUserPasswordAsync()
    {
        
    }
}