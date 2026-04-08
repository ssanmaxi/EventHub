using EventBooking.Domain.Enums;
using EventBooking.Domain.Models;
using EventPlanning.Application.Interfaces.Repositories;
using EventPlanning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.Infrastructure.Repositories;

public class BookingRepository :IBookingRepository
{
    private readonly AppDbContext _db;

    public BookingRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<Booking> GetBookingById(Guid id)
    {
        var entity = await _db.Bookings.FindAsync(id);

        return entity != null ? entity : throw new Exception("Booking was not found!");
    }

    public async Task<List<Booking>> GetBookingByUserId(Guid userId)
    {
        var entity = await _db.Bookings.Where(e=>e.UserId == userId).ToListAsync();

        return entity;
    }

    public async Task<List<Booking>> GetBookingByEventId(Guid eventId)
    {
        var entity = await _db.Bookings.Where(e=>e.EventId == eventId).ToListAsync();

        return entity;
    }

    public async Task<List<Booking>> GetWaitlistByEventId(Guid eventId)
    {
        var entity = await _db.Bookings.Where(e =>
            e.EventId == eventId
            && e.Status == BookingStatus.Waitlist).ToListAsync();

        return entity;
    }

    public async Task Create(Booking booking)
    {
        await _db.Bookings.AddAsync(booking);
    }
}