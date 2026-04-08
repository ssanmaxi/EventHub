using EventBooking.Infrastructure.Services;
using EventPlanning.Application.Interfaces.Auth_Interfaces;
using EventPlanning.Infrastructure.Interfaces.Auth_Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EventPlanning.Application.Dependency;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IGenerateToken, GenerateJwtToken>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}

