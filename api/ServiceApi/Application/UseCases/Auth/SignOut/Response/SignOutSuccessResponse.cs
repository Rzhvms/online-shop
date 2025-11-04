namespace Application.UseCases.Auth.SignOut.Response;

/// <summary>
/// Выходная модель успешной деавторизации пользователя
/// </summary>
public record SignOutSuccessResponse : SignOutResponse
{
    /// <summary>
    /// Сообщение о выходе пользователя (?)
    /// </summary>
    public string Message { get; set; }
}