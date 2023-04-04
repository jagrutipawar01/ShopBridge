using Microsoft.EntityFrameworkCore;

namespace Shopbridge.Data
{
  public class InventoryDbContext : DbContext
  {
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {  }

    public DbSet<Items> Items { get; set; }
  }
}
