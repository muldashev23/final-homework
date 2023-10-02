using Backend.DTOs;
using Backend.Entities;

namespace Backend.Interfaces;

public interface IShoesRepository
{
    void Update(Shoes shoes);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<ShoesResponseDto>> GetAllShoesAsync();
    Task<ShoesResponseDto> GetShoesByIdAsync(int name);
    Task<Shoes> GetShoesByIdForCartAsync(int id);
    Task<Shoes> GetShoo(int id);
}
