using EventBooking.Domain.Enums;

namespace EventPlanning.Application.DTO.Bookings_DTO;

public class BookingResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }
    public BookingStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}