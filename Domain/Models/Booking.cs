using EventBooking.Domain.Enums;

namespace EventBooking.Domain.Models;

public class Booking
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid EventId { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Booking(Guid userId, Guid eventId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        EventId = eventId;
        Status = BookingStatus.Booked;
        CreatedAt = DateTime.UtcNow;
    }

    public void CancelBooking()
    {
        Status = BookingStatus.Cancelled;
    }

    public void WaitlistBooking()
    {
        Status = BookingStatus.Waitlist;
    }

    public void Book()
    {
        Status = BookingStatus.Booked;
    }
}