using Api.Controllers.AuthController.Dto.Request;
using Api.Controllers.AuthController.Dto.Response;
using Api.UseCases.Interfaces;
using Logic.Models;
using Logic.Services.Interfaces;

namespace Api.UseCases;

public class AuthUseCase : IAuthUseCase
{
    private readonly IAuthService _authService;

    public AuthUseCase(IAuthService authService)
    {
        _authService = authService;
    }
    
    public async Task CreateUserAsync(CreateUserRequest request)
    {
        var userModel = new UserModel
        {
            UserName = request.Email,
            Name = request.Name,
            Surname = request.Surname,
            MiddleName = request.MiddleName,
            Email = request.Email,
            Phone = request.PhoneNumber,
            Password = request.Password
        };
        
        await _authService.CreateUserAsync(userModel);
    }

    public async Task<LoginUserResponse> LoginAsync(LoginUserRequest request)
    {
        var token = await _authService.LoginAsync(request.Username, request.Password);
        var response = new LoginUserResponse
        {
            Token = token
        };
        
        return response;
    }
}