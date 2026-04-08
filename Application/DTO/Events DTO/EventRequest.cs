namespace EventPlanning.Application.DTO.Events_DTO;

public class EventRequest
{
    public Guid OrganizerId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public string? Place { get; set; }
    public int MaxSeats { get; set; }
}