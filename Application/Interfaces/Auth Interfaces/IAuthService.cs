using EventPlanning.Application.DTO.Auth_DTO;
using EventPlanning.Application.DTO.Users_DTO;

namespace EventPlanning.Application.Interfaces.Auth_Interfaces;

public interface IAuthService
{
    Task<UserResponse> RegisterAsync(RegisterDto reg);
    Task<string> LoginAsync(LoginDto login);
}