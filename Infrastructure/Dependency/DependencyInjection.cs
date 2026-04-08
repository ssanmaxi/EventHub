using EventBooking.Application.Interfaces;
using EventBooking.Infrastructure.Services;
using EventPlanning.Application.Interfaces.Repositories;
using EventPlanning.Infrastructure.Persistence;
using EventPlanning.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
namespace EventPlanning.Infrastructure.Dependency;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("Postgres")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IBookingService, BookingService>();

        return services;
    }
}