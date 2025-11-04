namespace Application.UseCases.Auth.Login.Request;

/// <summary>
/// Входная модель для авторизации пользователя
/// </summary>
public record LoginRequest
{
    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
}