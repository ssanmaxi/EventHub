using EventBooking.Application.Interfaces;
using EventBooking.Domain.Enums;
using EventBooking.Domain.Models;
using EventPlanning.Application.DTO.Events_DTO;
using EventPlanning.Application.Interfaces.Repositories;

namespace EventBooking.Infrastructure.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _er;
    private readonly IUnitOfWork _uow;
    private readonly IWebHostEnvironment _wer;

    public EventService(IEventRepository er, IUnitOfWork uow, IWebHostEnvironment wer)
    {
        _er = er;
        _uow = uow;
        _wer = wer;
    }

    public async Task<EventResponse> CreateEvent(Guid orgId, string name, string description, DateTime date,
        string place, int maxSeats)
    {
        Event ev = new Event(orgId, name, description, date, place, maxSeats);

        await _er.CreateEvent(ev);
        await _uow.SaveChangesAsync();
        
        return MapToResponse(ev);
    }

    public async Task PublishEvent(Guid id)
    {
        var ev = await _er.GetEventById(id);

        if (ev == null) throw new Exception("Event was not found!");
        if (ev.Status != Status.Draft) throw new Exception("Only DRAFTS can be published!");
        
        ev.ActivateEvent();
        await _uow.SaveChangesAsync();
    }

    public async Task CancelEvent(Guid id)
    {
        var ev = await _er.GetEventById(id);

        if (ev == null) throw new Exception("Event was not found!");
        if (ev.Status != Status.Active) throw new Exception("You can only cancel an ACTIVE event!");

        ev.CancelEvent();
        await _uow.SaveChangesAsync();
    }

    public async Task PastEvent(Guid id)
    {
        var ev = await _er.GetEventById(id);

        if (ev == null) throw new Exception("Event was not found!");

        if (DateTime.UtcNow <= ev.Expiry) return;

        ev.MarkAsPastEvent();
        await _uow.SaveChangesAsync();
    }
    
    public async Task ChangeDescription(Guid id, string description)
    {
        var ev = await _er.GetEventById(id);

        if (ev == null) throw new Exception("No event was found!");

        ev.ChangeDescription(description);
        await _uow.SaveChangesAsync();
    }

    public async Task ChangePlace(Guid id, string place)
    {
        var ev = await _er.GetEventById(id);

        if (ev == null) throw new Exception("No event was found!");

        ev.ChangePlace(place);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<EventResponse>> GetEventsByStatus(Status status)
    {
        var ev = await _er.GetListOfEvents(status);

        return (ev.Select(e => MapToResponse(e))).ToList();
    }

    public async Task<EventResponse> GetEventById(Guid id)
    {
        var ev = await _er.GetEventById(id);

        if (ev == null) throw new Exception("Event was not found!");
        
        return MapToResponse(ev);
    }

    public async Task UploadEventPhoto(Guid id, IFormFile file)
    {
        var ev = await _er.GetEventById(id);

        if (ev == null) throw new Exception("Cannot upload photo for a nonexisting event!");
        
        var avatarsDir = Path.Combine(_wer.WebRootPath, "photos");
        Directory.CreateDirectory(avatarsDir);

        var ext = Path.GetExtension(file.FileName);
        var fileName = $"{id}_{Guid.NewGuid():N}{ext}";
        var savePath = Path.Combine(avatarsDir, fileName);

        await using (var stream = new FileStream(savePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var url = $"/photos/{fileName}";
        ev.AddPhoto(url);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<EventResponse>> SearchEvents(string query)
    {
        var ev = await _er.SearchEvents(query);
        return (ev.Select(e => MapToResponse(e))).ToList();
    }


    private static EventResponse MapToResponse(Event ev) => new EventResponse
    {
        OrganizerId = ev.OrganizerId,
        Id = ev.Id,
        Date = ev.Date,
        Description = ev.Description,
        Expiry = ev.Expiry,
        MaxSeats = ev.MaxSeats,
        Name = ev.Name,
        Place = ev.Place,
        Status = ev.Status,
        PhotoUrl = ev.PhotoUrl
    };
}