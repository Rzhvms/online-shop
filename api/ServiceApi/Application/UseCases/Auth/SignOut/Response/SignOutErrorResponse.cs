namespace Application.UseCases.Auth.SignOut.Response;

/// <summary>
/// Выходная модель деавторизации пользователя с ошибкой
/// </summary>
public record SignOutErrorResponse : SignOutResponse
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