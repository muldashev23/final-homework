using Backend.Data;
using Backend.DTOs;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class User : ControllerBase
{
    private readonly DataContext _context;

    public User(DataContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDTO loginData)
    {
        return Ok(loginData);
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Registration(
        [FromBody] RegistrationRequestDTO registrationData
    )
    {
        var user = new AppUser
        {
            UserName = registrationData.Username,
            Email = registrationData.Email,
            Password = registrationData.Password
        };
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return Ok(registrationData);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }
}
