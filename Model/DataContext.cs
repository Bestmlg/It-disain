using Microsoft.EntityFrameworkCore;

namespace It_disain.Model;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Test> Tests {get;set;}
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Shipment> Shipments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the one-to-many relationship between Shipment and Vehicle
        modelBuilder.Entity<Shipment>()
            .HasOne<Vehicle>(s => s.Vehicle)
            .WithMany(v => v.Shipments)
            .HasForeignKey(s => s.VehicleId);

        // Configure the many-to-many relationship between Shipment and Employee
        // Assume there is a join table for this relationship
        
        // Other relationships...
    }
}
