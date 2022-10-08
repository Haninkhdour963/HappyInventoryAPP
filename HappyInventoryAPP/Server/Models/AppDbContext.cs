using Microsoft.EntityFrameworkCore;

namespace HappyInventoryAPP.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items => Set<Item>();
        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<User> Users => Set<User>();

    }
}
