using System.Security.Cryptography;
using Application.Ports.Repositories;
using Application.Ports.Services;
using Application.UseCases.Auth.CreateUser;
using Application.UseCases.Auth.Login;
using Application.UseCases.Auth.RefreshToken;
using Application.UseCases.Auth.SignOut;
using Infrastructure.Repositories.Auth;
using Infrastructure.Services.Auth.Cryptography;
using Infrastructure.Services.Auth.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Api;

public class Startup
{
    private IWebHostEnvironment CurrentEnvironment { get; set; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Register services
        var jwtSettingsConfiguration = Configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(jwtSettingsConfiguration);
        var jwtSettings = jwtSettingsConfiguration.Get<JwtSettings>();

        services.AddSingleton<IAuthTokenService, JwtService>();
        services.AddSingleton<ICryptographyService, CryptographyService>();

        services.AddSingleton(provider =>
        {
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(source: Convert.FromBase64String(jwtSettings.AccessTokenSettings.PrivateKey),
                bytesRead: out int _);
            return new RsaSecurityKey(rsa);
        });


        // Register repositories
        services.AddSingleton<IAuthRepository, AuthRepository>();

        // Register use cases
        services.AddSingleton<LoginUseCase>();
        services.AddSingleton<RefreshTokenUseCase>();
        services.AddSingleton<SignOutUseCase>();
        services.AddSingleton<CreateUserUseCase>();

        // Controllers
        services.AddControllers();

        // Swagger
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth.API", Version = "v1" }); });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        CurrentEnvironment = env;

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth.API v1"));
        }

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}