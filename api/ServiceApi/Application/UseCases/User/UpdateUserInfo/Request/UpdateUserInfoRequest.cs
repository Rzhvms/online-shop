namespace Application.UseCases.User.UpdateUserInfo.Request;

/// <summary>
/// Входная модель обновления UserModel
/// </summary>
public record UpdateUserInfoRequest
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Номер телефона пользователя.
    /// </summary>
    public string? Phone { get; init; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string? LastName { get; init; }
}