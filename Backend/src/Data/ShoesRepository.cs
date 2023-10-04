using Backend.DTOs;
using Backend.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Backend.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

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

    public async Task<ShoesResponseDto> GetShoesByIdAsync(int id)
    {
        return await _context.Shoes
            .Where(x => x.Id == id)
            .ProjectTo<ShoesResponseDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }

    public async Task<Shoes> GetShoesByIdForCartAsync(int id)
    {
        return await _context.Shoes.Where(x => x.Id == id).SingleOrDefaultAsync();
    }

    public async Task<List<ShoesResponseDto>> GetAllShoesAsync()
    {
        return await _context.Shoes
            .ProjectTo<ShoesResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<List<ShoesResponseDto>> GetShoesByGender(string name)
    {
        var isForMan = false;
        if (name == "men")
        {
            isForMan = true;
        }
        return await _context.Shoes
            .Where(x => x.IsForMan == isForMan)
            .ProjectTo<ShoesResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<List<ShoesResponseDto>> GetShoesByBrand(string name)
    {
        return await _context.Shoes
            .Where(x => x.Brand == name)
            .ProjectTo<ShoesResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<string> AddShoes(ShoesRequestDTO shoes)
    {
        var shoesEntity = _mapper.Map<Shoes>(shoes);
        await _context.Shoes.AddAsync(shoesEntity);
        await _context.SaveChangesAsync();
        return "Shoes Added";
    }

    public async Task<string> DeleteShoes(int id)
    {
        var shoesToDelete = await _context.Shoes.SingleOrDefaultAsync(x => x.Id == id);
        _context.Shoes.Remove(shoesToDelete);
        await _context.SaveChangesAsync();
        return ("ok");
    }
}
