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
    public class InventoryItemController : ControllerBase
    {
        private readonly DataContext _context;

        public InventoryItemController(DataContext context)
        {
            _context = context;
        }

        // GET: api/InventoryItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventoryItems()
        {
            return await _context.InventoryItems.Include(i => i.Shipments).ToListAsync();
        }

        // GET: api/InventoryItem/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItem>> GetInventoryItem(int id)
        {
            var inventoryItem = await _context.InventoryItems
                .Include(i => i.Shipments)
                .FirstOrDefaultAsync(i => i.ItemId == id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return inventoryItem;
        }

        // POST: api/InventoryItem
        [HttpPost]
        public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem inventoryItem)
        {
            if (inventoryItem == null || string.IsNullOrWhiteSpace(inventoryItem.Name))
            {
                return BadRequest("Invalid inventory item data.");
            }

            _context.InventoryItems.Add(inventoryItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception details (ex)
                return StatusCode(500, "A problem occurred while saving the inventory item.");
            }

            return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.ItemId }, inventoryItem);
        }


        // PUT: api/InventoryItem/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryItem(int id, InventoryItem inventoryItem)
        {
            if (id != inventoryItem.ItemId)
            {
                return BadRequest("Inventory item ID mismatch.");
            }

            if (string.IsNullOrWhiteSpace(inventoryItem.Name))
            {
                return BadRequest("Invalid inventory item data.");
            }

            _context.Entry(inventoryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemExists(id))
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


        // DELETE: api/InventoryItem/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItem(int id)
        {
            var inventoryItem = await _context.InventoryItems.FindAsync(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            _context.InventoryItems.Remove(inventoryItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryItemExists(int id)
        {
            return _context.InventoryItems.Any(e => e.ItemId == id);
        }
    }
}
