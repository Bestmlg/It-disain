using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace It-disain.Model
{
    public class InventoryItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Dimensions { get; set; } // See võiks olla komplekssem objekt, näiteks Dimension tüüp
        public string Category { get; set; }
        public int Quantity { get; set; }
        public List<Shipment> Shipments { get; set; } // Mitmest-mitmesse seos Shipment klassiga
    }

}