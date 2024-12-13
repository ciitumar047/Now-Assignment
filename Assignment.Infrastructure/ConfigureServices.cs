using Assignment.Application.Common.Interfaces.Authentication;
using Assignment.Application.Common.Interfaces.Persistence.Base;
using Assignment.Application.Common.Interfaces.Persistence.Commands;
using Assignment.Application.Common.Interfaces.Persistence.Query;
using Assignment.Infrastructure.Authentication;
using Assignment.Infrastructure.DataContext;
using Assignment.Infrastructure.Persistence.Base;
using Assignment.Infrastructure.Persistence.Commands;
using Assignment.Infrastructure.Persistence.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Assignment.Application.Common.Services;

namespace Assignment.Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    ConfigurationManager configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistance()
            .AddDataContext(configuration);
        return services;
    }
    public static IServiceCollection AddDataContext(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<EfCoreContext>(options => options.UseSqlServer(connectionString));

        services.AddSingleton<DapperContext>();

        return services;
    }
    public static IServiceCollection AddPersistance(
        this IServiceCollection services)
    {
        services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
        services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
        services.AddTransient<IUserCommandRepository, UserCommandRepository>();
        services.AddTransient<IUserQueryRepository, UserQueryRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }

    public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

            });

        return services;
    }
}

