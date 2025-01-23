using JWT_TOKEN.Model;
using Microsoft.EntityFrameworkCore;

public class EComDbContext : DbContext
{
    // Parameterless constructor for design-time use
    public EComDbContext() { }

    // Constructor for runtime use
    public EComDbContext(DbContextOptions<EComDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    // Add other DbSets as needed
}
