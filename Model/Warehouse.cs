using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace It-disain.Model
{
    public class Warehouse
{
    public int WarehouseId { get; set; }
    public string Location { get; set; }
    public double Size { get; set; }
    public List<InventoryItem> InventoryItems { get; set; } // Ühest-mitmesse seos InventoryItem klassiga
}
}