using EventBooking.Application.Interfaces;
using EventBooking.Domain.Enums;
using EventPlanning.Application.DTO.Bookings_DTO;
using Microsoft.AspNetCore.Mvc;
using EventPlanning.Application.DTO.Events_DTO;
using Microsoft.AspNetCore.Authorization;

namespace EventPlanning.Presentation.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bs;

    public BookingController(IBookingService bs)
    {
        _bs = bs;
    }

    [Authorize(Roles = "User")]
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetMyBookings(Guid userId)
    {
        var bookings = await _bs.GetBookingByUserId(userId);

        return bookings.Count != 0 ? Ok(bookings) : Ok("No bookings found!");
    }

    [Authorize(Roles = "User")]
    [HttpPost()]
    public async Task<IActionResult> Book(BookingRequest book)
    {
        var booking = await _bs.BookEvent(book.UserId, book.EventId);

        return CreatedAtAction(nameof(GetMyBookings), new{userId = booking.UserId}, booking);
    }

    [Authorize(Roles = "User")]
    [HttpPatch("{id}/cancel")]
    public async Task<IActionResult> CancelBooking(Guid id)
    {
        await _bs.CancelBooking(id);

        return Ok();
    }
}