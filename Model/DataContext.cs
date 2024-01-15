using Microsoft.EntityFrameworkCore;

namespace It_disain.Model;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    { }

    public virtual DbSet<Test> Tests {get;set;}
    public virtual DbSet<Vehicle> Vehicles { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<InventoryItem> InventoryItems { get; set; }
    public virtual DbSet<Warehouse> Warehouses { get; set; }
    public virtual DbSet<Shipment> Shipments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Shipment>()
            .HasOne<Vehicle>(s => s.Vehicle)
            .WithMany(v => v.Shipments)
            .HasForeignKey(s => s.VehicleId);
    }
}
