namespace Application.UseCases.User.ChangeUserPassword.Request;

/// <summary>
/// Входная модель изменения пароль
/// </summary>
public record ChangeUserPasswordRequest
{
    /// <summary>
    /// Идентификатор пользвоателя
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Новый пароль
    /// </summary>
    public string NewPassword { get; init; }
    
    /// <summary>
    /// Старый пароль
    /// </summary>
    public string OldPassword { get; init; }
}