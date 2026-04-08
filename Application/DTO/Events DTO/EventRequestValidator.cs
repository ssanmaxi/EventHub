using FluentValidation;

namespace EventPlanning.Application.DTO.Events_DTO;

public class EventRequestValidator : AbstractValidator<EventRequest>
{
    public EventRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(350);
        RuleFor(x => x.Place).NotEmpty();
        RuleFor(x => x.MaxSeats).GreaterThan(0);
        RuleFor(x => x.Date).GreaterThan(DateTime.UtcNow);
        RuleFor(x => x.OrganizerId).NotEmpty();
    }
}