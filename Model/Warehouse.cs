using System.ComponentModel.DataAnnotations;

namespace It_disain.Model
{
    public class Warehouse
{
    [Key]
    public int WarehouseId { get; set; }
    public string Location { get; set; }
    public double Size { get; set; }
    public List<InventoryItem> InventoryItems { get; set; } // Ühest-mitmesse seos InventoryItem klassiga
}
}