namespace Application.UseCases.User.ChangeUserPassword.Response;

/// <summary>
/// Выходная модель изменения пароль
/// </summary>
public record ChangeUserPasswordResponse
{
    /// <summary>
    /// Флаг, успешно или нет
    /// </summary>
    public bool IsSuccess { get; init; }
    
    /// <summary>
    /// Сообщение о состоянии изменения пароля
    /// </summary>
    public string? Message { get; init; }
}