using EventBooking.Application.Interfaces;
using EventBooking.Domain.Models;
using EventPlanning.Application.Interfaces.Repositories;
using EventPlanning.Infrastructure.Persistence;


namespace EventBooking.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}