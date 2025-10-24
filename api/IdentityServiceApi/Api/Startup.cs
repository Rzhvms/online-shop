using Dal;
using Logic;

namespace Api;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogic();
        services.AddDal();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
    }
}