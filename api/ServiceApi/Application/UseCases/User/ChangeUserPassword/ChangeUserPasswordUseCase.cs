using Application.Ports.Repositories;
using Application.Ports.Services;
using Application.UseCases.User.ChangeUserPassword.Request;
using Application.UseCases.User.ChangeUserPassword.Response;

namespace Application.UseCases.User.ChangeUserPassword;

/// <inheritdoc />
public class ChangeUserPasswordUseCase : IChangeUserPasswordUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptographyService _cryptoService;
    private readonly IAuthRepository _authRepository;
    
    public ChangeUserPasswordUseCase(
        IUserRepository userRepository,
        ICryptographyService cryptoService,
        IAuthRepository authRepository)
    {
        _userRepository = userRepository;
        _cryptoService = cryptoService;
        _authRepository = authRepository;
    }
    
    /// <inheritdoc />
    public async Task<ChangeUserPasswordResponse> ExecuteAsync(ChangeUserPasswordRequest request)
    {
        var user = await _authRepository.GetUserByUserIdAsync(request.Id);
        if (user == null)
        {
            return new ChangeUserPasswordResponse
            {
                IsSuccess = false,
                Message = "Пользователь не найден"
            };
        }

        // Хэшируем старый пароль тем же Salt
        var oldPasswordHash = _cryptoService.HashPassword(request.OldPassword, user.Salt);

        if (oldPasswordHash != user.Password)
        {
            return new ChangeUserPasswordResponse
            {
                IsSuccess = false,
                Message = "Старый пароль неверный"
            };
        }

        // Хэшируем новый пароль
        var newPasswordHash = _cryptoService.HashPassword(request.NewPassword, user.Salt);

        await _userRepository.ChangeUserPasswordAsync(user.Id, newPasswordHash, user.Salt);

        return new ChangeUserPasswordResponse
        {
            IsSuccess = true,
            Message = "Пароль успешно изменён"
        };
    }
}