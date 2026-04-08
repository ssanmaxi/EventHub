using FluentValidation;

namespace EventPlanning.Application.DTO.Bookings_DTO;

public class BookingRequestValidator : AbstractValidator<BookingRequest>
{
    public BookingRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.EventId).NotEmpty();
    }
}