using Application.UseCases.User.GetUserInfo.Request;
using Application.UseCases.User.GetUserInfo.Response;

namespace Application.UseCases.User.GetUserInfo;

/// <summary>
/// UseCase по получению базовой информации о пользователе
/// </summary>
public interface IGetUserInfoUseCase
{
    /// <summary>
    /// Выполнение поиска пользователя
    /// </summary>
    Task<GetUserInfoResponse> ExecuteAsync(GetUserInfoRequest request);
}