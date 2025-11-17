using Application.Ports.Repositories;
using Application.UseCases.User.UpdateUserInfo.Request;
using Application.UseCases.User.UpdateUserInfo.Response;
using Domain.User;

namespace Application.UseCases.User.UpdateUserInfo;

/// <inheritdoc />
public class UpdateUserInfoUseCase : IUpdateUserInfoUseCase
{
    private readonly IUserRepository _userRepository;
    
    public UpdateUserInfoUseCase(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    /// <inheritdoc />
    public async Task<UpdateUserInfoResponse> ExecuteAsync(UpdateUserInfoRequest request)
    {
        var result = await _userRepository.UpdateUserInfoAsync(request.Id, request.Phone, request.Name, request.LastName);
        var (id, updateAt) = result;
        var response = new UpdateUserInfoResponse()
        {
            Id = id,
            UpdateAt = updateAt
        };
        return response;
    }
}