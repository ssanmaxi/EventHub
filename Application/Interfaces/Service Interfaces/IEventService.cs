using EventBooking.Domain.Enums;
using EventBooking.Domain.Models;
using EventPlanning.Application.DTO.Events_DTO;

namespace EventBooking.Application.Interfaces;

public interface IEventService
{
    Task<EventResponse> CreateEvent(Guid orgId, string name, string description, DateTime date,
        string place, int maxSeats);

    Task PublishEvent(Guid id);
    Task CancelEvent(Guid id);
    Task PastEvent(Guid id);
    Task ChangeDescription(Guid id, string description);
    Task ChangePlace(Guid id, string place);
    Task<List<EventResponse>> GetEventsByStatus(Status status);
    Task<EventResponse> GetEventById(Guid id);
    Task UploadEventPhoto(Guid id, IFormFile file);
    Task<List<EventResponse>> SearchEvents(string query);
}