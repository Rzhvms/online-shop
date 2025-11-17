using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.UserController;

/// <summary>
/// Контроллер по управлению пользовательскими данными (Профиль)
/// </summary>
[Authorize]
[ApiController]
[Route("api/user/profile")]
public class UserProfileController : ControllerBase
{
    public UserProfileController()
    {
        
    }
    
    /// <summary>
    /// Получить профиль пользователя
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task GetUserProfileAsync()
    {
        
    }
    
    /// <summary>
    /// Обновить профиль пользователя.
    /// </summary>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task UpdateUserProfileAsync()
    {
        
    }
}