using Backend.DTOs;
using Backend.Entities;

namespace Backend.Interfaces;

public interface IShoesRepository
{
    void Update(Shoes shoes);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<ShoesResponseDto>> GetAllShoesAsync();
    Task<ShoesResponseDto> GetShoesByIdAsync(int name);
}
