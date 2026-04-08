using EventBooking.Application.Interfaces;
using EventBooking.Domain.Models;
using EventPlanning.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using EventPlanning.Infrastructure.Persistence;
using EventBooking.Domain.Enums;
using EventBooking.Infrastructure.Services;

namespace EventPlanning.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly AppDbContext _db;

    public EventRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<Event?> GetEventById(Guid id)
    {
        var entity = await _db.Events.FindAsync(id);

        return entity;
    }

    public async Task<List<Event>> GetListOfEvents(Status status)
    {
        var entity = await _db.Events.Where(e => e.Status == status).ToListAsync();

        return entity;
    }
    
    public async Task CreateEvent(Event ev)
    {
        await _db.Events.AddAsync(ev);
    }

    public async Task DeleteEventById(Guid id)
    {
        var del = await _db.Events.FindAsync(id);
        if (del == null) throw new Exception("No event was found!");
        _db.Events.Remove(del);
    }

    public async Task<List<Event>> SearchEvents(string query)
    {
        var events = await _db.Events.Where(q => q.Name.Contains(query)
                                                 && q.Status == Status.Active).ToListAsync();

        return events;
    }

    public async Task ChangeDescription(Guid id, string description)
    {
        var ev = await _db.Events.FindAsync(id);

        if (ev == null) throw new Exception("No event was found!");

        ev.ChangeDescription(description);
    }

    public async Task ChangePlace(Guid id, string place)
    {
        var ev = await _db.Events.FindAsync(id);

        if (ev == null) throw new Exception("No event was found!");

        ev.ChangePlace(place);
    }
}