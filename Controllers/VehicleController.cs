using It_disain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using It_disain.Model; 
using Microsoft.EntityFrameworkCore; // Vahetage see oma andmebaasi konteksti nimeruumi vastu, kui kasutate EF Core'i

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly DataContext _context; 

    public VehicleController(DataContext context)
    {
        _context = context;
    }

    // GET: api/Vehicle
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
    {
        return await _context.Vehicles.ToListAsync();
    }

    // GET: api/Vehicle/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
        {
            return NotFound();
        }

        return vehicle;
    }

    // POST: api/Vehicle
    [HttpPost]
    public async Task<ActionResult<Vehicle>> CreateVehicle(Vehicle vehicle)
    {
        if (vehicle == null || string.IsNullOrWhiteSpace(vehicle.Type))
        {
            return BadRequest("Invalid vehicle data.");
        }

        _context.Vehicles.Add(vehicle);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            // Log the exception details (ex)
            return StatusCode(500, "A problem occurred while saving the vehicle.");
        }

        return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.VehicleId }, vehicle);
    }


    // PUT: api/Vehicle/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicle(int id, Vehicle vehicle)
    {
        if (id != vehicle.VehicleId)
        {
            return BadRequest("Vehicle ID mismatch.");
        }

        if (string.IsNullOrWhiteSpace(vehicle.Type))
        {
            return BadRequest("Invalid vehicle data.");
        }

        _context.Entry(vehicle).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VehicleExists(id))
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


    // DELETE: api/Vehicle/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VehicleExists(int id)
    {
        return _context.Vehicles.Any(e => e.VehicleId == id);
    }
}
