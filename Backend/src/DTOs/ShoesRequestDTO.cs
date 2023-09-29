namespace Backend.DTOs;

public class ShoesRequestDTO
{
    public required string Name { get; set; }

    public required string Brand { get; set; }

    public required float Price { get; set; }

    public required int Amount { get; set; }

    public required int Available { get; set; }

    public List<PhotoDTO> Photos { get; set; } = new();
}
