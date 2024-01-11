using Microsoft.EntityFrameworkCore;

namespace It_disain.Model;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Test>? Tests { get; set; }
    public DbSet<Vehicle>? Vehicles { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<InventoryItem>? InventoryItems { get; set; }
    public DbSet<Warehouse>? Warehouses { get; set; }
    public DbSet<Shipment>? Shipments { get; set; }
}
