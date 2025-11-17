namespace Application.UseCases.User.UpdateUserInfo.Response;

/// <summary>
/// Выходная модель обновления UserModel
/// </summary>
public record UpdateUserInfoResponse
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Дата последнего обновления данных пользователя.
    /// </summary>
    public DateTime? UpdateAt { get; init; }
}