namespace EventPlanning.Application.DTO.Bookings_DTO;

public class BookingRequest
{
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }
}