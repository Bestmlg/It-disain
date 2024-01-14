using System.ComponentModel.DataAnnotations;

namespace It_disain.Model
{
    public class InventoryItem
    {
        [Key]
        public int ItemId { get; init; }
        public string Name { get; init; }
        public double Weight { get; init; }
        public string Dimensions { get; init; } // See võiks olla komplekssem objekt, näiteks Dimension tüüp
        public string Category { get; init; }
        public int Quantity { get; init; }
        public List<Shipment> Shipments { get; init; } // Mitmest-mitmesse seos Shipment klassiga
    }

}