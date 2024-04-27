using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgeryController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        public SurgeryController(HospitalDbContext context)
        {
            _context = context;
        }
        // Get all Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Surgery>>> GetSurgeryProcedure()
        {
            return await _context.Surgeries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Surgery>> GetSurgeryProcedureById(int id)
        {
            if (_context.Surgeries == null)
            {
                return NotFound();
            }
            var surgeryProcedure = await _context.Surgeries.FindAsync(id);
            if (surgeryProcedure == null)
            {
                return NotFound();
            }
            return surgeryProcedure;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurgeryProcedure(int id, Surgery surgeryProcedure)
        {
            if (id != surgeryProcedure.SurgeryID)
            {
                return BadRequest();
            }
            _context.Entry(surgeryProcedure).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!SurgeryProcedureExists(id))
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

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<Surgery>> PostSurgeryProcedure(Surgery surgeryProcedure)
        {
            if (_context.Surgeries == null)
            {
                return Problem("Entity set 'Surgery' is null");
            }
            _context.Surgeries.Add(surgeryProcedure);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSurgeryProcedure", new { id = surgeryProcedure.SurgeryID });
        }

        private bool SurgeryProcedureExists(int id)
        {
            return (_context.Surgeries?.Any(e => e.SurgeryID == id)).GetValueOrDefault();
        }
    }
}
