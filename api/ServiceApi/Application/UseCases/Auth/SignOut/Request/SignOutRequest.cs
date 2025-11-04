namespace Application.UseCases.Auth.SignOut.Request;

/// <summary>
/// Входная модель деавторизации пользователя
/// </summary>
public record SignOutRequest
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
}