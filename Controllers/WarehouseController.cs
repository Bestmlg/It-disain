using It_disain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace It_disain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly DataContext _context;

        public WarehouseController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Warehouse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouses()
        {
            return await _context.Warehouses
                .Include(w => w.InventoryItems)
                .ToListAsync();
        }

        // GET: api/Warehouse/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
        {
            var warehouse = await _context.Warehouses
                .Include(w => w.InventoryItems)
                .FirstOrDefaultAsync(w => w.WarehouseId == id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // POST: api/Warehouse
        [HttpPost]
        public async Task<ActionResult<Warehouse>> PostWarehouse(Warehouse warehouse)
        {
            if (warehouse == null || string.IsNullOrWhiteSpace(warehouse.Location))
            {
                return BadRequest("Invalid warehouse data.");
            }

            _context.Warehouses.Add(warehouse);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                
                return StatusCode(500, "A problem occurred while saving the warehouse.");
            }

            return CreatedAtAction("GetWarehouse", new { id = warehouse.WarehouseId }, warehouse);
        }


        // PUT: api/Warehouse/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarehouse(int id, Warehouse warehouse)
        {
            if (id != warehouse.WarehouseId)
            {
                return BadRequest("Warehouse ID mismatch.");
            }

            if (string.IsNullOrWhiteSpace(warehouse.Location))
            {
                return BadRequest("Invalid warehouse data.");
            }

            _context.Entry(warehouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/Warehouse/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WarehouseExists(int id)
        {
            return _context.Warehouses.Any(e => e.WarehouseId == id);
        }
    }
}
