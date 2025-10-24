using Logic.Services;
using Logic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Logic;

public static class ForStartupLogic
{
    public static IServiceCollection AddLogic(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        
        return services;
    }
}