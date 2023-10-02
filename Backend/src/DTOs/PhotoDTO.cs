namespace Backend.DTOs;

public class PhotoDTO
{
    public int Id { get; set; }
    public required string Url { get; set; }
    public required bool IsMain { get; set; }
}
