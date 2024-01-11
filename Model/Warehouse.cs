using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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