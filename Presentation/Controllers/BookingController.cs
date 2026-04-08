using EventBooking.Application.Interfaces;
using EventBooking.Domain.Enums;
using EventPlanning.Application.DTO.Bookings_DTO;
using Microsoft.AspNetCore.Mvc;
using EventPlanning.Application.DTO.Events_DTO;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace EventPlanning.Presentation.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bs;
    private readonly IValidator<BookingRequest> _iv;

    public BookingController(IBookingService bs, IValidator<BookingRequest> iv)
    {
        _bs = bs;
        _iv = iv;
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
        var result = await _iv.ValidateAsync(book);
        if (!result.IsValid) return BadRequest(result.Errors);
        
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