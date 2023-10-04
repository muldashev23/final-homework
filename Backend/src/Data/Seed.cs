using System.Text.Json;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class Seed
{
    public static async Task SeedShoes(DataContext context)
    {
        if (await context.Shoes.AnyAsync())
            return;
        var shoesData = await File.ReadAllTextAsync("Data/ShoesSeedData.json");
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var shoes = JsonSerializer.Deserialize<List<Shoes>>(shoesData);
        foreach (var shoe in shoes)
        {
            shoe.Name = shoe.Name.ToLower();
            context.Shoes.Add(shoe);
        }
        await context.SaveChangesAsync();
    }
}
