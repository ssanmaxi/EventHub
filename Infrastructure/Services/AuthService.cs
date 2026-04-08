using EventBooking.Application.Interfaces;
using EventBooking.Domain.Models;
using EventPlanning.Application.DTO.Auth_DTO;
using EventPlanning.Application.DTO.Users_DTO;
using EventPlanning.Application.Interfaces.Auth_Interfaces;
using EventPlanning.Application.Interfaces.Repositories;

namespace EventBooking.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IGenerateToken _gt;
    private readonly IPasswordHasher _ph;
    private readonly IUnitOfWork _uow;
    private readonly IUserRepository _ur;

    public AuthService(IGenerateToken gt, IPasswordHasher ph, IUnitOfWork uow, IUserRepository ur)
    {
        _gt = gt;
        _ph = ph;
        _uow = uow;
        _ur = ur;
    }
    public async Task<UserResponse> RegisterAsync(RegisterDto reg)
    {
        if (await _ur.FindUserByEmailAsync(reg.Email) != null) throw new Exception("An email is already in use!");
        
        var hashed = _ph.Hash(reg.Password);

        var user = new User(reg.Name, reg.Email, hashed, reg.Role);
        await _ur.AddAsync(user);
        await _uow.SaveChangesAsync();
        var token = _gt.GenerateToken(user);

        return new UserResponse
        {
            Name = user.Name,
            Email = user.Email,
            Token = token,
            Role = reg.Role
        };
    }

    public async Task<string> LoginAsync(LoginDto login)
    {
        var user = await _ur.FindUserByEmailAsync(login.Email);

        if (user == null) throw new Exception("No user found with this email!");

        if (!_ph.Verify(login.Password, user.PasswordHash)) throw new Exception("Passowords do not match!");

        return _gt.GenerateToken(user);
    }
}