using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options)
        : base(options) { }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Shoes> Shoes { get; set; }
    public DbSet<Cart> Carts { get; set; }
}
