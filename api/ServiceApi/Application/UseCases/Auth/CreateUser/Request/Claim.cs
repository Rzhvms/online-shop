namespace Application.UseCases.Auth.CreateUser.Request;

/// <summary>
/// Представляет право или роль пользователя.
/// </summary>
public record Claim
{
    /// <summary>
    /// Тип права/роли
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Значение права/роли
    /// </summary>
    public string Value { get; set; }
}