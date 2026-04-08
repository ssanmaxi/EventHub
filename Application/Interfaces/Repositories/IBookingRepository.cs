using EventBooking.Domain.Enums;
using EventBooking.Domain.Models;
namespace EventPlanning.Application.Interfaces.Repositories;

public interface IBookingRepository
{
    public Task<Booking> GetBookingById(Guid id);
    public Task<List<Booking>> GetBookingByUserId(Guid userId);
    public Task<List<Booking>> GetBookingByEventId(Guid eventId);
    public Task<List<Booking>> GetWaitlistByEventId(Guid eventId);
    public Task Create(Booking booking);
    //public Task UpdateInfo(Guid id);
}