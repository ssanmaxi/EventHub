using EventBooking.Domain.Enums;

namespace EventPlanning.Application.DTO.Events_DTO;

public class EventResponse
{
    public Guid OrganizerId { get; set; }
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public string? Place { get; set; }
    public int MaxSeats { get; set; }
    public Status Status { get; set; }
    public DateTime Expiry { get; set; }
    public string? PhotoUrl { get; set; }
}