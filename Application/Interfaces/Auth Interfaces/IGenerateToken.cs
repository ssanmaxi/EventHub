using EventBooking.Domain.Models;

namespace EventPlanning.Application.Interfaces.Auth_Interfaces;

public interface IGenerateToken
{
    string GenerateToken(User user);
}