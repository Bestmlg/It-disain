using It_disain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class InventoryItemController : ControllerBase
{
    // Siin võiks olla teie teenused või andmebaasi kontekst

    // GET: api/InventoryItem
    [HttpGet]
    public ActionResult<IEnumerable<InventoryItem>> GetAllInventoryItems()
    {
        // Kood andmebaasist kõigi inventuurüksuste pärimiseks
        return new List<InventoryItem>();
    }

    // GET: api/InventoryItem/5
    [HttpGet("{id}")]
    public ActionResult<InventoryItem> GetInventoryItem(int id)
    {
        // Kood konkreetse inventuurüksuse pärimiseks
        return NoContent();
    }

    // POST: api/InventoryItem
    [HttpPost]
    public IActionResult CreateInventoryItem([FromBody] InventoryItem item)
    {
        // Kood uue inventuurüksuse lisamiseks andmebaasi
        return NoContent();
    }

    // PUT: api/InventoryItem/5
    [HttpPut("{id}")]
    public IActionResult UpdateInventoryItem(int id, [FromBody] InventoryItem item)
    {
        // Kood olemasoleva inventuurüksuse uuendamiseks
        return NoContent();
    }

    // DELETE: api/InventoryItem/5
    [HttpDelete("{id}")]
    public IActionResult DeleteInventoryItem(int id)
    {
        // Kood inventuurüksuse kustutamiseks andmebaasist
        return NoContent();
    }
}
