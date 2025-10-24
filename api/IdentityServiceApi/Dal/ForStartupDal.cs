using Dal.Repositories;
using Dal.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dal;

public static class ForStartupDal
{
    public static IServiceCollection AddDal(this IServiceCollection services)
    {
        services.AddTransient<IAuthRepository, AuthRepository>();
        
        return services;
    }
}