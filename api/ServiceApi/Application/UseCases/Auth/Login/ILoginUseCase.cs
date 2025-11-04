using Application.UseCases.Auth.Login.Request;
using Application.UseCases.Auth.Login.Response;

namespace Application.UseCases.Auth.Login;

/// <summary>
/// Use case для авторизации пользователя.
/// Выполняет проверку учетных данных, генерацию JWT и refresh-токена.
/// </summary>
public interface ILoginUseCase
{
    /// <summary>
    /// Выполняет авторизацию пользователя.
    /// </summary>
    Task<LoginResponse> ExecuteAsync(LoginRequest request);
}