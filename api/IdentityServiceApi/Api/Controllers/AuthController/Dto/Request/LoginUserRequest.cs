namespace Api.Controllers.AuthController.Dto.Request;

/// <summary>
/// Входная модель авторизации пользователя
/// </summary>
public record LoginUserRequest
{
    /// <summary>
    /// Логин
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
}