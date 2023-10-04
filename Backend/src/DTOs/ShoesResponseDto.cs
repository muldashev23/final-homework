namespace Backend.DTOs;

public class ShoesResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string PhotoUrl { get; set; }

    public required string Brand { get; set; }

    public required float Price { get; set; }

    public required int Amount { get; set; }

    public required int Available { get; set; }

    public required bool IsForMan { get; set; }

    public List<PhotoDTO> Photos { get; set; } = new();
    public List<SizeDTO> Sizes { get; set; } = new();
}
