using Microsoft.EntityFrameworkCore;

namespace ITB2203Application.Model;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    // DbSet tüübid teie mudelitele
    public DbSet<InventoryItem> InventoryItems { get; set; }
    // Võite lisada siia ka teisi DbSets, näiteks Shipment, Vehicle, Warehouse, jne.
    // public DbSet<Shipment> Shipments { get; set; }
    // public DbSet<Vehicle> Vehicles { get; set; }
    // public DbSet<Warehouse> Warehouses { get; set; }

    // Ülekirjutage OnModelCreating, kui soovite kohandada mudelite käitumist
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Siin saate määratleda täiendavaid konfiguratsioone, näiteks:
        // modelBuilder.Entity<InventoryItem>().ToTable("inventory_items");
    }
}