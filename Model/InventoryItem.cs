using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace It_disain.Model
{
    public class InventoryItem
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Dimensions { get; set; } // See võiks olla komplekssem objekt, näiteks Dimension tüüp
        public string Category { get; set; }
        public int Quantity { get; set; }
        public List<Shipment> Shipments { get; set; } // Mitmest-mitmesse seos Shipment klassiga
    }

}