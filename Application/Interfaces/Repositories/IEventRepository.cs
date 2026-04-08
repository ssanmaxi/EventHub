using EventBooking.Domain.Enums;
using EventBooking.Domain.Models;
namespace EventPlanning.Application.Interfaces.Repositories;

public interface IEventRepository
{
   Task<Event?> GetEventById(Guid id);
   Task<List<Event>> GetListOfEvents(Status status);
   Task CreateEvent(Event ev);
   Task ChangeDescription(Guid id, string description);
   Task ChangePlace(Guid id, string place);
   Task DeleteEventById(Guid id);
   Task<List<Event>> SearchEvents(string query);
}