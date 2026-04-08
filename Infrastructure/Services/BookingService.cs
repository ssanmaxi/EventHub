using EventBooking.Application.Interfaces;
using EventBooking.Domain.Enums;
using EventBooking.Domain.Models;
using EventPlanning.Application.DTO.Bookings_DTO;
using EventPlanning.Application.Interfaces.Repositories;

namespace EventBooking.Infrastructure.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _br;
    private readonly IEventRepository _er;
    private readonly IUnitOfWork _uow;

    public BookingService(IBookingRepository br, IEventRepository er, IUnitOfWork uow)
    {
        _br = br;
        _er = er;
        _uow = uow;
    }

    public async Task<BookingResponse> BookEvent(Guid userId, Guid eventId)
    {
        var ev = await _er.GetEventById(eventId);

        if (ev == null) throw new Exception("Event was not found");
        if (ev.Status != Status.Active) throw new Exception("Event is not active");

        var booking = new Booking(userId, eventId);

        var bookedNum = (await _br.GetBookingByEventId(eventId)).Count(b=>b.Status == BookingStatus.Booked);

        if (bookedNum >= ev.MaxSeats)
        {
            booking.WaitlistBooking();
        }
        
        await _br.Create(booking);
        await _uow.SaveChangesAsync();

        return MapToResponse(booking);
    }

    public async Task CancelBooking(Guid id)
    {
        var booking = await _br.GetBookingById(id);

        if (booking == null) throw new Exception("Booking was not found!");

        if (booking.Status != BookingStatus.Booked) throw new Exception("You can only cancel booked events!");

        booking.CancelBooking();

        var waitlist = await _br.GetWaitlistByEventId(booking.EventId);
        if (waitlist.Count == 0)
        {
            await _uow.SaveChangesAsync();
            return;
        }

        var first = waitlist.OrderBy(f => f.CreatedAt).First();

        first.Book();
        await _uow.SaveChangesAsync();
    }

    public async Task<List<BookingResponse>> GetBookingByUserId(Guid userId)
    {
        var bookings = await _br.GetBookingByUserId(userId);

        var ans = bookings.Select(b => MapToResponse(b)).ToList();

        return ans;
    }
    
    private static BookingResponse MapToResponse(Booking b) => new BookingResponse
    {
        Id = b.Id,
        UserId = b.UserId,
        EventId = b.EventId,
        Status = b.Status
    };
}