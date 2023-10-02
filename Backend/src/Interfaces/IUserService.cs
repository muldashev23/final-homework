using Backend.DTOs;
using Backend.Entities;

namespace Backend.Interfaces;

public interface IUserService
{
    Task<UserDTO> GetUserById(int id);
    Task<AppUser> GetUserByIdForCart(int id);
}
