using Microsoft.EntityFrameworkCore;

public class LogisticsDbContext : DbContext
{
    public DbSet<InventoryItem> InventoryItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("teie_andmebaasi_ühenduse_string");
    }
}