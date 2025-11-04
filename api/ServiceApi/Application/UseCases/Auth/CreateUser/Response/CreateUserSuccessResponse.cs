namespace Application.UseCases.Auth.CreateUser.Response;

/// <summary>
/// Выходная модель с успешным созданием пользователя
/// </summary>
public record CreateUserSuccessResponse : CreateUserResponse
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; internal set; }
}