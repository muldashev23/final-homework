using Backend.Entities;

namespace Backend.DTOs;

public class CartResponseDTO
{
    public int Id { get; set; }
    public List<ShoesResponseDto> Shoes { get; set; }
    public List<SelectedSizeDTO> SelectedSizes { get; set; }
}
