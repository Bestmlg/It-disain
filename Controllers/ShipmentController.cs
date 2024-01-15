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
    public class ShipmentController : ControllerBase
    {
        private readonly DataContext _context;

        public ShipmentController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Shipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
        {
            return await _context.Shipments
                .Include(s => s.Vehicle)
                .Include(s => s.InventoryItems)
                .ToListAsync();
        }

        // GET: api/Shipment/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipment(int id)
        {
            var shipment = await _context.Shipments
                .Include(s => s.Vehicle)
                .Include(s => s.InventoryItems)
                .FirstOrDefaultAsync(s => s.ShipmentId == id);

            if (shipment == null)
            {
                return NotFound();
            }

            return shipment;
        }

        // POST: api/Shipment
        [HttpPost]
        public async Task<ActionResult<Shipment>> PostShipment(Shipment shipment)
        {
            if (shipment == null || string.IsNullOrWhiteSpace(shipment.Destination) || string.IsNullOrWhiteSpace(shipment.Origin))
            {
                return BadRequest("Invalid shipment data.");
            }

            _context.Shipments.Add(shipment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                
                return StatusCode(500, "A problem occurred while saving the shipment.");
            }

            return CreatedAtAction("GetShipment", new { id = shipment.ShipmentId }, shipment);
        }


        // PUT: api/Shipment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipment(int id, Shipment shipment)
        {
            if (id != shipment.ShipmentId)
            {
                return BadRequest("Shipment ID mismatch.");
            }

            if (string.IsNullOrWhiteSpace(shipment.Destination) || string.IsNullOrWhiteSpace(shipment.Origin))
            {
                return BadRequest("Invalid shipment data.");
            }

            _context.Entry(shipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentExists(id))
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


        // DELETE: api/Shipment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(int id)
        {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }

            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipmentExists(int id)
        {
            return _context.Shipments.Any(e => e.ShipmentId == id);
        }
    }
}
