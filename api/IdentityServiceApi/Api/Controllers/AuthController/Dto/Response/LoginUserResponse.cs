namespace Api.Controllers.AuthController.Dto.Response;

/// <summary>
/// Выходная модель авторизации пользователя
/// </summary>
public record LoginUserResponse
{
    /// <summary>
    /// JWT токен
    /// </summary>
    public string Token { get; set; }
}