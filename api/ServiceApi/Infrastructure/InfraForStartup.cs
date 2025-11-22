using System.Data;
using System.Security.Cryptography;
using Application.Ports.Repositories;
using Application.Ports.Services;
using Application.Ports.Services.Email;
using FluentMigrator.Runner;
using Infrastructure.Migrations;
using Infrastructure.Repositories.Auth;
using Infrastructure.Repositories.User;
using Infrastructure.Services.Auth.Cryptography;
using Infrastructure.Services.Auth.Jwt;
using Infrastructure.Services.Email;
using Infrastructure.Services.Email.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Npgsql;

namespace Infrastructure;

public static class InfraForStartup
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, JwtSettings jwtSettings, string connectionString)
    {
        // Сервисы криптографии
        services.AddSingleton<ICryptographyService, CryptographyService>();

        // RSA ключи
        services.AddSingleton<RsaSecurityKey>(sp =>
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(jwtSettings.AccessTokenSettings.PrivateKey); // PEM
            return new RsaSecurityKey(rsa);
        });

        services.AddSingleton<IAuthTokenService>(sp =>
        {
            var rsaKey = sp.GetRequiredService<RsaSecurityKey>();
            return new JwtService(Options.Create(jwtSettings), rsaKey);
        });

        // Postgres
        services.AddScoped<IDbConnection>(sp =>
        {
            var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            return conn;
        });

        // Репозитории
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // FluentMigrator
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(Date_202511011900_AddTables_UserDal_ClaimDal_RefreshTokenDal).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());

        
        // Email
        services.AddScoped<IMailHelper, MailHelper>();
        services.AddScoped<IEmailClient, EmailClient>();
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}