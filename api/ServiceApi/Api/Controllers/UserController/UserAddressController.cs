using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.UserController;

/// <summary>
/// Контроллер по управлению пользовательскими данными (Адрес)
/// </summary>
[Authorize]
[ApiController]
[Route("api/user/address")]
public class UserAddressController : ControllerBase
{
    public UserAddressController()
    {
        
    }
    
    /// <summary>
    /// Получить адрес пользователя
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task GetUserAddressAsync()
    {
        
    }

    /// <summary>
    /// Добавить новый адрес пользователя
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task AddUserAddressAsync()
    {
        
    }

    /// <summary>
    /// Обновить существующий адрес пользователя по идентификатору
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task UpdateUserAddressAsync(Guid id)
    {
        
    }

    /// <summary>
    /// Удалить адрес пользователя по идентификатору
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task DeleteUserAddressAsync(Guid id)
    {
        
    }
}