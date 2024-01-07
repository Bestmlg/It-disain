using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("inventory_items")]
public class InventoryItem
{
    [Key]
    [Column("item_id")]
    public int Id { get; set; }

    [Column("item_name")]
    public string Name { get; set; }

    [Column("item_weight")]
    public double Weight { get; set; }

    [Column("item_category")]
    public string Category { get; set; }

    [Column("item_quantity")]
    public int Quantity { get; set; }

    
}