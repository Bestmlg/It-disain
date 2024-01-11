using It_disain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ShipmentController : ControllerBase
{
    // GET: api/Shipment
    [HttpGet]
    public ActionResult<IEnumerable<Shipment>> GetShipments()
    {
        // Siin võiks olla kood, mis pärib kõik saadetised andmebaasist
        return new List<Shipment>(); // Tegelikult peaks siin tagastama andmebaasi päringu tulemused
    }

    // GET: api/Shipment/5
    [HttpGet("{id}")]
    public ActionResult<Shipment> GetShipment(int id)
    {
        // Siin võiks olla kood, mis pärib konkreetse saadetise andmebaasist
        return new Shipment(); // Tegelikult peaks siin tagastama konkreetse saadetise andmebaasist
    }

    // POST: api/Shipment
    [HttpPost]
    public IActionResult CreateShipment(Shipment shipment)
    {
        // Siin võiks olla kood, mis lisab uue saadetise andmebaasi
        return CreatedAtAction("GetShipment", new { id = shipment.ShipmentId }, shipment);
    }

    // PUT: api/Shipment/5
    [HttpPut("{id}")]
    public IActionResult UpdateShipment(int id, Shipment shipment)
    {
        // Siin võiks olla kood, mis uuendab saadetist andmebaasis
        return NoContent();
    }

    // DELETE: api/Shipment/5
    [HttpDelete("{id}")]
    public IActionResult DeleteShipment(int id)
    {
        // Siin võiks olla kood, mis kustutab saadetise andmebaasist
        return NoContent();
    }
}
