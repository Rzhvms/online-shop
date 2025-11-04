using Application.UseCases.Auth.CreateUser;
using Application.UseCases.Auth.Login;
using Application.UseCases.Auth.RefreshToken;
using Application.UseCases.Auth.SignOut;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationForStartup
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddScoped<ILoginUseCase, LoginUseCase>();
        services.AddScoped<IRefreshTokenUseCase, RefreshTokenUseCase>();
        services.AddScoped<ISignOutUseCase, SignOutUseCase>();
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();

        return services;
    }
}