using System.Security.Cryptography;
using System.Text;
using Backend.Data;
using Backend.DTOs;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

public class AccountController : BaseApiController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context, ITokenService tokenService)
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
            Id = user.Id,
            Username = user.UserName,
            Token = _tokenService.CreateToken(user),
            IsAdmin = user.Role == "Admin"
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
            Role = "User",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registrationData.Password)),
            PasswordSalt = hmac.Key
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return new LoginResponseDTO
        {
            Id = user.Id,
            Username = user.UserName,
            Token = _tokenService.CreateToken(user),
            IsAdmin = user.Role == "Admin"
        };
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult> DeleteUser([FromRoute] int id)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        var authenticatedUser = HttpContext.User;
        var userIdClaim = authenticatedUser.Claims.FirstOrDefault(claim => claim.Type == "userId");
        if (userIdClaim == null)
        {
            return Forbid();
        }

        if ((user.Id.ToString() != userIdClaim.Value) && !authenticatedUser.IsInRole("Admin"))
        {
            return Forbid();
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<UserDTO>> EditUser(
        [FromRoute] int id,
        [FromBody] UserUpdateDTO user
    )
    {
        var authenticatedUser = HttpContext.User;
        var userIdClaim = authenticatedUser.Claims.FirstOrDefault(claim => claim.Type == "userId");

        var userById = await _context.Users.FindAsync(id);

        if (userById == null)
        {
            return NotFound(new { wrongId = true });
        }

        if (userIdClaim == null)
        {
            return Forbid();
        }

        if ((userById.Id.ToString() != userIdClaim.Value) && !authenticatedUser.IsInRole("Admin"))
        {
            return Forbid();
        }

        var userByEmail = await _context.Users.FirstOrDefaultAsync(
            userFound => userFound.Email == user.Email
        );
        if (userByEmail != null && userByEmail.Id != id)
        {
            return Conflict(new { takenEmail = true });
        }

        var hmac = new HMACSHA512();
        hmac.Key = userById.PasswordSalt;
        var oldPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
        if (oldPassword != userById.PasswordHash)
        {
            return Conflict(new { error = "Wrong Credentials" });
        }
        if (user.NewPassword != user.ConfirmPassword)
        {
            return Conflict(new { error = "Confirm Password Not Matching" });
        }
        userById.UserName = user.Username;
        userById.Email = user.Email;
        userById.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.NewPassword));
        userById.PasswordSalt = hmac.Key;

        if (authenticatedUser.IsInRole("Admin"))
        {
            userById.Role = user.Role;
        }

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    private async Task<bool> VerifyUser(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email == email.ToLower());
    }
}
