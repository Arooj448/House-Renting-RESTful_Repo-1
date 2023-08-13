using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationWebApi_Arooj.Data;
using WebApplicationWebApi_Arooj.Model;

namespace WebApplicationWebApi_Arooj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        private readonly HouseRentingDbContext _context;

        public HousesController(HouseRentingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            return await _context.Houses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(int id)
        {
            var house = await _context.Houses.FindAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            return house;
        }

        [HttpPost]
        public async Task<ActionResult<House>> PostHouse(House house)
        {
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHouse", new { id = house.Id }, house);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(int id, House house)
        {
            if (id != house.Id)
            {
                return BadRequest();
            }

            _context.Entry(house).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HouseExists(int id)
        {
            return _context.Houses.Any(e => e.Id == id);
        }
    }
}
