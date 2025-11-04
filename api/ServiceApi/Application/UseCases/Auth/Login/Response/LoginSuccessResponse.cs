namespace Application.UseCases.Auth.Login.Response;

/// <summary>
/// Ответ на успешную авторизацию пользователя.
/// Содержит необходимые токены для дальнейшей работы с API.
/// </summary>
public record LoginSuccessResponse : LoginResponse
{
    /// <summary>
    /// JWT идентификационный токен пользователя (ID token).
    /// Используется для аутентификации и передачи информации о пользователе.
    /// </summary>
    public string IdToken { get; set; }

    /// <summary>
    /// JWT access-токен для доступа к защищенным ресурсам API.
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// Refresh-токен, используемый для получения нового access-токена после истечения срока действия.
    /// </summary>
    public string RefreshToken { get; set; }
}