using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace It_disain.Model
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public string Status { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }  // Seose loomiseks Vehicle klassiga
        public List<InventoryItem> InventoryItems { get; set; } // Mitmest-mitmesse seos InventoryItem klassiga
    }
}