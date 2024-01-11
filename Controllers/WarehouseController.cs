using It_disain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


[Route("api/[controller]")]
[ApiController]
public class WarehouseController : ControllerBase
{
    // GET: api/Warehouse
    [HttpGet]
    public ActionResult<IEnumerable<Warehouse>> GetWarehouses()
    {
        // Kood andmebaasist kõigi ladude pärimiseks
        return NoContent();
    }

    // GET: api/Warehouse/5
    [HttpGet("{id}")]
    public ActionResult<Warehouse> GetWarehouse(int id)
    {
        // Kood konkreetse lao pärimiseks
        return NoContent();
    }

    // POST: api/Warehouse
    [HttpPost]
    public IActionResult CreateWarehouse([FromBody] Warehouse warehouse)
    {
        // Kood uue lao lisamiseks andmebaasi
        return NoContent();
    }

    // PUT: api/Warehouse/5
    [HttpPut("{id}")]
    public IActionResult UpdateWarehouse(int id, [FromBody] Warehouse warehouse)
    {
        // Kood olemasoleva lao uuendamiseks
        return NoContent();
    }

    // DELETE: api/Warehouse/5
    [HttpDelete("{id}")]
    public IActionResult DeleteWarehouse(int id)
    {
        // Kood lao kustutamiseks andmebaasist
        return NoContent();
    }
}
