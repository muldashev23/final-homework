using Backend.DTOs;
using Backend.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Backend.Interfaces;

namespace Backend.Data;

public class ShoesRepository : IShoesRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ShoesRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Update(Shoes shoes)
    {
        _context.Entry(shoes).State = EntityState.Modified;
    }

    public async Task<ShoesResponseDto> GetShoesAsync(string name)
    {
        return await _context.Shoes
            .Where(x => x.Name == name)
            .ProjectTo<ShoesResponseDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<ShoesResponseDto>> GetAllShoesAsync()
    {
        return await _context.Shoes
            .ProjectTo<ShoesResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
