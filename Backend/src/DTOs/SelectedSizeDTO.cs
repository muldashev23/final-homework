namespace Backend.DTOs;

public class SelectedSizeDTO
{
    public int Id { get; set; }
    public required int SizeNum { get; set; }
    public required int SelectedShoesId { get; set; }
    public required int ShoesIdForSize { get; set; }
    public required int Amount { get; set; }
}
