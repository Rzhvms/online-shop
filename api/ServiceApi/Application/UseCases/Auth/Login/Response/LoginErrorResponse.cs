namespace Application.UseCases.Auth.Login.Response;

/// <summary>
/// Ответ на неуспешную авторизацию пользователя.
/// Содержит код ошибки и текстовое сообщение для клиента.
/// </summary>
public record LoginErrorResponse : LoginResponse
{
    /// <summary>
    /// Текстовое сообщение с описанием ошибки.
    /// </summary>
    public string? Message { get; internal set; }

    /// <summary>
    /// Код ошибки.
    /// </summary>
    public string Code { get; internal set; }
}