using System.Security.Cryptography;
using System.Text;
using API.Controllers;
using Backend.Data;
using Backend.DTOs;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

public class Account : BaseApiController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public Account(DataContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginData)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == loginData.Email);
        if (user == null)
            return Unauthorized("User with this email does't exist");
        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginData.Password));
        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i])
                return Unauthorized("Invalid Password!");
        }
        return new LoginResponseDTO
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }

    [HttpPost("registration")]
    public async Task<ActionResult<LoginResponseDTO>> Registration(
        [FromBody] RegistrationRequestDTO registrationData
    )
    {
        if (await VerifyUser(registrationData.Email))
            return BadRequest("Email is taken");

        using var hmac = new HMACSHA512();
        var user = new AppUser
        {
            UserName = registrationData.Username.ToLower(),
            Email = registrationData.Email.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registrationData.Password)),
            PasswordSalt = hmac.Key
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return new LoginResponseDTO
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }

    [HttpGet]
    private async Task<bool> VerifyUser(string username)
    {
        return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
    }
}
