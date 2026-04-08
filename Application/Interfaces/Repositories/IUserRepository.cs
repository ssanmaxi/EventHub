using EventBooking.Domain.Models;
namespace EventPlanning.Application.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<User?> FindUserByIdAsync(Guid id);
    public Task<User?> FindUserByEmailAsync(string email);
    public Task AddAsync(User user);
}