using EventBooking.Domain.Models;
using EventPlanning.Application.DTO.Bookings_DTO;

namespace EventBooking.Application.Interfaces;

public interface IBookingService
{
    Task<BookingResponse> BookEvent(Guid userId, Guid eventId);
    Task CancelBooking(Guid id);
    Task<List<BookingResponse>> GetBookingByUserId(Guid userId);
}