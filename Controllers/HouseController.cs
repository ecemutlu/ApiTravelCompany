using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTravelCompany.Db;
using ApiTravelCompany.Models;

namespace ApiTravelCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly TravelContext _context;

        public HouseController(TravelContext context)
        {
            _context = context;
        }

        // GET: api/House
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            return await _context.Houses.ToListAsync();
        }

        // GET: api/House/5
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(string id)
        {
            var house = await _context.Houses.FindAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            return house;
        }

        // PUT: api/House/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(string id, House house)
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

        // POST: api/House
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<House>> PostHouse(House house)
        {
            house.Id = Guid.NewGuid().ToString();
            _context.Houses.Add(house);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HouseExists(house.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHouse", new { id = house.Id }, house);
        }

        // DELETE: api/House/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(string id)
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

        private bool HouseExists(string id)
        {
            return _context.Houses.Any(e => e.Id == id);
        }
    }
}
