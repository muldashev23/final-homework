﻿namespace Backend.DTOs;

public class ShoesRequestDTO
{
    public required string Name { get; set; }

    public required string Brand { get; set; }

    public required float Price { get; set; }

    public required int Amount { get; set; }

    public required int Available { get; set; }
    public required bool IsForMan { get; set; }

    public required List<PhotoDTO> Photos { get; set; } = new();
    public required List<SizeDTO> Sizes { get; set; } = new();
}
