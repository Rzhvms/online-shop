namespace Application.UseCases.User.GetUserInfo.Request;

/// <summary>
/// Входная модель по получению базовой информации о пользователе
/// </summary>
public record GetUserInfoRequest
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid Id { get; init; }
}