using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace It_disain.Model
{
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public string Status { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }  
        public List<InventoryItem> InventoryItems { get; set; } 
    }
}