using EventBooking.Domain.Enums;
namespace EventBooking.Domain.Models;

public class Event
{
    public Guid Id { get; private set; }
    public Guid OrganizerId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public string? Place { get; private set; }
    public int MaxSeats { get; private set; }
    public Status Status { get; private set; }
    public DateTime Expiry { get; private set; }
    public string? PhotoUrl { get; private set; }

    public Event(Guid organizerId, string name, string description, 
        DateTime date, string place, int maxSeats)
    {
        OrganizerId = organizerId;
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Date = date;
        Place = place;
        MaxSeats = maxSeats;
        Status = Status.Draft;
        Expiry = date.AddDays(7);
    }

    public void ChangeDescription(string description)
    {
        Description = description;
    }

    public void ChangePlace(string place)
    {
        Place = place;
    }

    public void ActivateEvent()
    {
        Status = Status.Active;
    }

    public void CancelEvent()
    {
        Status = Status.Cancelled;
    }

    public void MarkAsPastEvent()
    {
        Status = Status.Past;
    }

    public void ExtendEvent()
    {
        Expiry = Expiry.AddDays(1);
    }

    public void AddPhoto(string url)
    {
        PhotoUrl = url;
    }
}