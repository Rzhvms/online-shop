using Application.Ports.Repositories;
using Application.UseCases.User.GetUserInfo.Request;
using Application.UseCases.User.GetUserInfo.Response;

namespace Application.UseCases.User.GetUserInfo;

/// <inheritdoc />
public class GetUserInfoUseCase : IGetUserInfoUseCase
{
    private readonly IUserRepository _userRepository;
    public GetUserInfoUseCase(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    /// <inheritdoc />
    public async Task<GetUserInfoResponse> ExecuteAsync(GetUserInfoRequest request)
    {
        var result = await _userRepository.GetUserInfoAsync(request.Id);
        var response = new GetUserInfoResponse()
        {
            Name = result.Name,
            LastName = result.LastName,
            Email = result.Email,
            Phone = result.Phone,
            CreateAt = result.CreateAt,
            UpdateAt = result.UpdateAt
        };
        return response;
    }
}