using EventBooking.Domain.Enums;

namespace EventPlanning.Application.DTO.Auth_DTO;

public class RegisterDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required Role Role { get; set; }
}