using Microsoft.AspNetCore.Mvc;
using CompanyApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly AppDbContext _context;

    public VehiclesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Vehicles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
    {
        return await _context.Vehicles.ToListAsync();
    }

    // GET: api/Vehicles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.VehicleId == id);

        if (vehicle == null)
        {
            return NotFound();
        }

        return vehicle;
    }

    // POST: api/Vehicles
    [HttpPost]
    public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.VehicleId }, vehicle);
    }

    // PUT: api/Vehicles/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
    {
        if (id != vehicle.VehicleId)
        {
            return BadRequest();
        }

        _context.Entry(vehicle).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Vehicles.Any(v => v.VehicleId == id))
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

    // DELETE: api/Vehicles/5
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
}
