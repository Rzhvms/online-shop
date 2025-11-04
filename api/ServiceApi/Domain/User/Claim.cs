namespace Domain.User;

/// <summary>
/// Представляет право или роль пользователя.
/// Используется для авторизации и контроля доступа.
/// </summary>
public class Claim
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