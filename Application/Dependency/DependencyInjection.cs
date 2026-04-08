using EventBooking.Infrastructure.Services;
using EventPlanning.Application.DTO.Bookings_DTO;
using EventPlanning.Application.DTO.Events_DTO;
using EventPlanning.Application.Interfaces.Auth_Interfaces;
using EventPlanning.Infrastructure.Interfaces.Auth_Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace EventPlanning.Application.Dependency;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IGenerateToken, GenerateJwtToken>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddValidatorsFromAssemblyContaining<EventRequestValidator>();
        
        return services;
    }
}

