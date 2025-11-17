using Application.UseCases.User.ChangeUserPassword.Request;
using Application.UseCases.User.ChangeUserPassword.Response;

namespace Application.UseCases.User.ChangeUserPassword;

/// <summary>
/// UseCase изменения пароля
/// </summary>
public interface IChangeUserPasswordUseCase
{
    /// <summary>
    /// Изменяем пароль
    /// </summary>
    Task<ChangeUserPasswordResponse> ExecuteAsync(ChangeUserPasswordRequest request);
}