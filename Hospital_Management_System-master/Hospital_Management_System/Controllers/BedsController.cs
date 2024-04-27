using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public BedsController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/Bed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bed>>> GetBeds()
        {
            return await _context.Beds.ToListAsync();
        }

        // GET: api/Bed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bed>> GetBed(int id)
        {
            var bed = await _context.Beds.FindAsync(id);

            if (bed == null)
            {
                return NotFound();
            }

            return bed;
        }

        // POST: api/Bed
        [HttpPost]
        public async Task<ActionResult<Bed>> PostBed(Bed bed)
        {
            _context.Beds.Add(bed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBed", new { id = bed.BedID }, bed);
        }

        // PUT: api/Bed/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBed(int id, Bed bed)
        {
            if (id != bed.BedID)
            {
                return BadRequest();
            }

            _context.Entry(bed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BedExists(id))
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

        // DELETE: api/Bed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBed(int id)
        {
            var bed = await _context.Beds.FindAsync(id);
            if (bed == null)
            {
                return NotFound();
            }

            _context.Beds.Remove(bed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BedExists(int id)
        {
            return _context.Beds.Any(e => e.BedID == id);
        }
    }
}
