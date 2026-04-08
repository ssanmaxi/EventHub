using EventBooking.Application.Interfaces;
using EventBooking.Domain.Enums;
using EventPlanning.Application.DTO.Auth_DTO;
using EventPlanning.Application.Interfaces.Auth_Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace EventPlanning.Presentation.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _as;

    public AuthController(IAuthService as1)
    {
        _as = as1;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterDto reg)
    {
        var result = await _as.RegisterAsync(reg);

        return Ok(new { token = result.Token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginDto login)
    {
        var result = await _as.LoginAsync(login);

        return Ok(new { token = result });
    }
}