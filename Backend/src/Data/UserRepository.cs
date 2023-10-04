using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.DTOs;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class UserRepository : IUserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDTO> GetUserById(int id)
    {
        return await _context.Users
            .Where(x => x.Id == id)
            .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }

    public async Task<AppUser> GetUserByIdForCart(int id)
    {
        return await _context.Users
            .Include(u => u.Cart)
            .ThenInclude(c => c.Shoes)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}
