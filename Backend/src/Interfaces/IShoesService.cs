using Backend.DTOs;
using Backend.Entities;

namespace Backend.Interfaces;

public interface IShoesRepository
{
    void Update(Shoes shoes);
    Task<bool> SaveAllAsync();
    Task<List<ShoesResponseDto>> GetAllShoesAsync();
    Task<ShoesResponseDto> GetShoesByIdAsync(int name);
    Task<Shoes> GetShoesByIdForCartAsync(int id);
    Task<List<ShoesResponseDto>> GetShoesByGender(string name);
    Task<List<ShoesResponseDto>> GetShoesByBrand(string name);
    Task<string> AddShoes(ShoesRequestDTO shoes);
    Task<string> DeleteShoes(int id);
}
