using EventBooking.Application.Interfaces;
using EventBooking.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using EventPlanning.Application.DTO.Events_DTO;
using Microsoft.AspNetCore.Authorization;

namespace EventPlanning.Presentation.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController :ControllerBase
{
    private readonly IEventService _es;

    public EventsController(IEventService es)
    {
        _es = es;
    }
    
    [AllowAnonymous]
    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetEventsByStatus(Status status)
    {
        var events = await _es.GetEventsByStatus(status);

        return Ok(events);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(Guid id)
    {
        var ev = await _es.GetEventById(id);

        return Ok(ev);
    }

    [Authorize(Roles = "Organizer")]
    [HttpPost("create")]
    public async Task<IActionResult> CreateEvent(EventRequest evq)
    {
        var ev = await _es.CreateEvent(evq.OrganizerId, evq.Name, evq.Description, 
            DateTime.SpecifyKind(evq.Date, DateTimeKind.Utc), evq.Place, evq.MaxSeats);

        return CreatedAtAction(nameof(GetEventById), new{id = ev.Id}, ev);
    }

    [Authorize(Roles = "Organizer")]
    [HttpPatch("{id}/publish")]
    public async Task<IActionResult> PublishEvent(Guid id)
    {
        await _es.PublishEvent(id);

        return Ok();
    }

    [Authorize(Roles = "Organizer")]
    [HttpPatch("{id}/cancel")]
    public async Task<IActionResult> CancelEvent(Guid id)
    {
        await _es.CancelEvent(id);
        
        return Ok();
    }

    [Authorize(Roles = "Organizer")]
    [HttpPatch("{id}/past")]
    public async Task<IActionResult> PastEvent(Guid id)
    {
        await _es.PastEvent(id);

        return Ok();
    }

    [Authorize(Roles = "Organizer")]
    [HttpPatch("{id}/change-description")]
    public async Task<IActionResult> ChangeDescription(Guid id, string description)
    {
        await _es.ChangeDescription(id, description);

        return Ok();
    }

    [Authorize(Roles = "Organizer")]
    [HttpPatch("{id}/change-place")]
    public async Task<IActionResult> ChangePlace(Guid id, string place)
    {
        await _es.ChangePlace(id, place);
        return Ok();
    }

    [Authorize(Roles = "Organizer")]
    [HttpPost("{id}/event-photo")]
    public async Task<IActionResult> AddPhoto(Guid id, [FromForm] IFormFile file)
    {
        await _es.UploadEventPhoto(id, file);
        return Ok();
    }

    [Authorize]
    [HttpGet("search")]
    public async Task<IActionResult> SearchEvents(string query)
    {
        var events = await _es.SearchEvents(query);

        return Ok(events);
    }
}