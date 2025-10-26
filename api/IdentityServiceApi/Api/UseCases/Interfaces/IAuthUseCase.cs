using Api.Controllers.AuthController.Dto.Request;
using Api.Controllers.AuthController.Dto.Response;

namespace Api.UseCases.Interfaces;

public interface IAuthUseCase
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    Task CreateUserAsync(CreateUserRequest request);

    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    Task<LoginUserResponse> LoginAsync(LoginUserRequest request);
}