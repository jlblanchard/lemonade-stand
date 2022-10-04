using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class LemonadeContext : DbContext
    {
        public LemonadeContext(DbContextOptions<LemonadeContext> options) : base(options)
        {}

        public DbSet<Lemonade> Lemonades { get; set; } = null!;
    }
}