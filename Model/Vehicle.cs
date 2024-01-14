using System.ComponentModel.DataAnnotations;

namespace It_disain.Model
{
    public class Vehicle
{
    [Key]
    public int VehicleId { get; set; }
    public string Type { get; set; }
    public string Location { get; set; }
    public string MaintenanceDates { get; set; } // See võiks olla kuupäevade list või muu struktuur
    public string Status { get; set; }
    public List<Shipment> Shipments{get;set;}
}

}