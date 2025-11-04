namespace Application.UseCases.Auth.RefreshToken.Response;

/// <summary>
/// Выходная модель обновления токена с ошибкой
/// </summary>
public record RefreshTokenErrorResponse : RefreshTokenResponse
{
    /// <summary>
    /// Текстовое сообщение с описанием ошибки.
    /// </summary>
    public string? Message { get; internal set; }

    /// <summary>
    /// Код ошибки.
    /// </summary>
    public string Code { get; internal set; }
}