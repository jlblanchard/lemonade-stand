using Microsoft.EntityFrameworkCore;

namespace api.Models;
public class LemonadeContext : DbContext
{
    public LemonadeContext(DbContextOptions<LemonadeContext> options) : base(options)
    {}

    public DbSet<Lemonade> Lemonades { get; set; } = null!;
    public DbSet<Size> Size { get; set; } = null!;
    public DbSet<Type> Type { get; set; } = null!;
    public DbSet<Order> Order { get; set; } = null!;
    public DbSet<OrderItem> OrderItem { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Size>();
        modelBuilder.Entity<Type>();
    }
}