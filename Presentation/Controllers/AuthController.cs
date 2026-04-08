using EventBooking.Application.Interfaces;
using EventBooking.Domain.Enums;
using EventPlanning.Application.DTO.Auth_DTO;
using EventPlanning.Application.Interfaces.Auth_Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
namespace EventPlanning.Presentation.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _as;
    private readonly IValidator<LoginDto> _iv1;
    private readonly IValidator<RegisterDto> _iv2;

    public AuthController(IAuthService as1, IValidator<LoginDto> iv1, IValidator<RegisterDto> iv2)
    {
        _as = as1;
        _iv1 = iv1;
        _iv2 = iv2;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterDto reg)
    {
        var result1 = await _iv2.ValidateAsync(reg);
        if (!result1.IsValid) return BadRequest(result1.Errors);
        
        var result = await _as.RegisterAsync(reg);

        return Ok(new { token = result.Token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginDto login)
    {
        var result1 = await _iv1.ValidateAsync(login);
        if (!result1.IsValid) return BadRequest(result1.Errors);
        
        var result = await _as.LoginAsync(login);

        return Ok(new { token = result });
    }
}