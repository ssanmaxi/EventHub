using EventBooking.Domain.Enums;

namespace EventPlanning.Application.DTO.Users_DTO;

public class UserResponse
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Token { get; set; }
    public required Role Role { get; set; }
}