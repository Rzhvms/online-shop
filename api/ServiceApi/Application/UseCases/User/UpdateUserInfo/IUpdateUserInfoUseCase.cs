using Application.UseCases.User.UpdateUserInfo.Request;
using Application.UseCases.User.UpdateUserInfo.Response;

namespace Application.UseCases.User.UpdateUserInfo;

/// <summary>
/// Обновить информацию пользователя (UserModel)
/// </summary>
public interface IUpdateUserInfoUseCase
{
    /// <summary>
    /// Обновить информацию пользователя (UserModel)
    /// </summary>
    Task<UpdateUserInfoResponse> ExecuteAsync(UpdateUserInfoRequest request);
}