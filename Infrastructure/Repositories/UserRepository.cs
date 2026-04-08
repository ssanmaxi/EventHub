using EventBooking.Application.Interfaces;
using EventBooking.Domain.Models;
using EventBooking.Infrastructure.Services;
using EventPlanning.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using EventPlanning.Infrastructure.Persistence;

namespace EventPlanning.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<User?> FindUserByIdAsync(Guid id)
    {
        var entity = await _db.Users.FindAsync(id);

        return entity;
    }

    public async Task<User?> FindUserByEmailAsync(string email)
    {
        var entity = await _db.Users.FirstOrDefaultAsync(e => e.Email == email);

        return entity;
    } 

    public async Task AddAsync(User user)
    {
        await _db.Users.AddAsync(user);
    }
    
}