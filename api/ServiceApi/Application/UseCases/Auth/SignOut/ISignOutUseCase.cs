using Application.UseCases.Auth.SignOut.Request;
using Application.UseCases.Auth.SignOut.Response;

namespace Application.UseCases.Auth.SignOut;

/// <summary>
/// Юзкейс выхода пользователя из системы (инвалидация refresh-токена).
/// </summary>
public interface ISignOutUseCase
{
    /// <summary>
    /// Выполняет выход пользователя, деактивируя refresh-токен.
    /// </summary>
    Task<SignOutResponse> ExecuteAsync(SignOutRequest request);
}