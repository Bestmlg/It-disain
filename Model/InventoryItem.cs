using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace It_disain.Model
{
    
    public class InventoryItem
    {
        [Key]
        public int ItemId { get; init; }
        public string Name { get; init; }
        [Column("Kaal")]
        public double Weight { get; init; }
        public string Dimensions { get; init; }
        public string Category { get; init; }
        public int Quantity { get; init; }
        public List<Shipment> Shipments { get; init; } 
    }

}