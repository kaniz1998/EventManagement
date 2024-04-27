using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardCabinController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public WardCabinController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/WardCabin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WardCabin>>> GetWardCabins()
        {
            return await _context.WardCabins.ToListAsync();
        }

        // GET: api/WardCabin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WardCabin>> GetWardCabin(int id)
        {
            var wardCabin = await _context.WardCabins.FindAsync(id);

            if (wardCabin == null)
            {
                return NotFound();
            }

            return wardCabin;
        }

        // POST: api/WardCabin
        [HttpPost]
        public async Task<ActionResult<WardCabin>> PostWardCabin(WardCabin wardCabin)
        {
            _context.WardCabins.Add(wardCabin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWardCabin", new { id = wardCabin.WardID }, wardCabin);
        }

        // PUT: api/WardCabin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWardCabin(int id, WardCabin wardCabin)
        {
            if (id != wardCabin.WardID)
            {
                return BadRequest();
            }

            _context.Entry(wardCabin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WardCabinExists(id))
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

        // DELETE: api/WardCabin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWardCabin(int id)
        {
            var wardCabin = await _context.WardCabins.FindAsync(id);
            if (wardCabin == null)
            {
                return NotFound();
            }

            _context.WardCabins.Remove(wardCabin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WardCabinExists(int id)
        {
            return _context.WardCabins.Any(e => e.WardID == id);
        }
        //private readonly HospitalDbContext _context;
        //public WardCabinController(HospitalDbContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<WardCabin>>> GetWardCabins()
        //{
        //    return await _context.WardCabins.ToListAsync();
        //}


        //[HttpGet("{id}")]
        //public async Task<ActionResult<WardCabin>> GetWardCabinById(int id)
        //{
        //    var wardCabin = await _context.WardCabins.FindAsync(id);
        //    return wardCabin;
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutWardCabin(int id, WardCabin wardCabin)
        //{
        //    _context.Entry(wardCabin).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return Ok(wardCabin);
        //}


        //[HttpPost]
        //[Route("insert")]
        //public async Task<ActionResult<WardCabin>> PostWardCabin(WardCabin wardCabin)
        //{
        //    _context.WardCabins.Add(wardCabin);
        //    await _context.SaveChangesAsync();
        //    return Ok(wardCabin);
        //}


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteWardCabin(int id)
        //{
        //    var wardCabin = await _context.WardCabins.FindAsync(id);
        //    _context.WardCabins.Remove(wardCabin);
        //    await _context.SaveChangesAsync();
        //    return Ok(wardCabin);
        //}

        //private bool WardCabinExists(int id)
        //{
        //    return (_context.WardCabins?.Any(e => e.WardID == id)).GetValueOrDefault();
        //}
    }
}
