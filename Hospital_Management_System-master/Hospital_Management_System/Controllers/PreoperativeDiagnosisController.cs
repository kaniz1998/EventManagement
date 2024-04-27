using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreoperativeDiagnosisController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public PreoperativeDiagnosisController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/PreoperativeDiagnosis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreoperativeDiagnosis>>> GetPreoperativeDiagnoses()
        {
            return await _context.PreoperativeDiagnoses.ToListAsync();
        }

        // GET: api/PreoperativeDiagnosis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreoperativeDiagnosis>> GetPreoperativeDiagnosis(int id)
        {
            var preoperativeDiagnosis = await _context.PreoperativeDiagnoses.FindAsync(id);

            if (preoperativeDiagnosis == null)
            {
                return NotFound();
            }

            return preoperativeDiagnosis;
        }

        // POST: api/PreoperativeDiagnosis
        [HttpPost]
        public async Task<ActionResult<PreoperativeDiagnosis>> PostPreoperativeDiagnosis(PreoperativeDiagnosis preoperativeDiagnosis)
        {
            _context.PreoperativeDiagnoses.Add(preoperativeDiagnosis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreoperativeDiagnosis", new { id = preoperativeDiagnosis.PreoperativeDiagnosisID }, preoperativeDiagnosis);
        }

        // PUT: api/PreoperativeDiagnosis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreoperativeDiagnosis(int id, PreoperativeDiagnosis preoperativeDiagnosis)
        {
            if (id != preoperativeDiagnosis.PreoperativeDiagnosisID)
            {
                return BadRequest();
            }

            _context.Entry(preoperativeDiagnosis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreoperativeDiagnosisExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(preoperativeDiagnosis);
        }

        // DELETE: api/PreoperativeDiagnosis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreoperativeDiagnosis(int id)
        {
            var preoperativeDiagnosis = await _context.PreoperativeDiagnoses.FindAsync(id);
            if (preoperativeDiagnosis == null)
            {
                return NotFound();
            }

            _context.PreoperativeDiagnoses.Remove(preoperativeDiagnosis);
            await _context.SaveChangesAsync();

            return Ok("Data Deleted Successfully!!!");
        }

        private bool PreoperativeDiagnosisExists(int id)
        {
            return _context.PreoperativeDiagnoses.Any(e => e.PreoperativeDiagnosisID == id);
        }
    }
}
