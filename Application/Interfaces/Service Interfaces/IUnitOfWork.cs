namespace EventBooking.Application.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}