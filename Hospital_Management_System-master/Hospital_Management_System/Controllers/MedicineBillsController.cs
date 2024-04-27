using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineBillsController : ControllerBase
    {
        private readonly HospitalDbContext _db;

        public MedicineBillsController(HospitalDbContext db)
        {
            _db = db;
        }

        // GET: api/MedicineBills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicineBill>>> GetMedicineBills()
        {
            return await _db.MedicineBills.ToListAsync();
        }

        // GET: api/MedicineBills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicineBill>> GetMedicineBill(int id)
        {
            var medicineBill = await _db.MedicineBills.FindAsync(id);

            if (medicineBill == null)
            {
                return NotFound();
            }

            return medicineBill;
        }

        // POST: api/MedicineBills
        [HttpPost]
        public async Task<ActionResult<MedicineBill>> PostMedicineBill(MedicineBill medicineBill)
        {
            if (medicineBill == null)
            {
                return BadRequest("MedicineBill object is null");
            }

            _db.MedicineBills.Add(medicineBill);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetMedicineBill", new { id = medicineBill.MedicineBillId }, medicineBill);
        }

        // PUT: api/MedicineBills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicineBill(int id, MedicineBill medicineBill)
        {
            if (id != medicineBill.MedicineBillId)
            {
                return BadRequest("Invalid request");
            }

            _db.Entry(medicineBill).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineBillExists(id))
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

        // DELETE: api/MedicineBills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMedicineBill(int id)
        {
            try
            {
                var medicineBill = await _db.MedicineBills.FindAsync(id);
                if (medicineBill == null)
                {
                    return NotFound($"MedicineBill record with ID {id} not found.");
                }
                return BadRequest("MedicineBill record can't be deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool MedicineBillExists(int id)
        {
            return _db.MedicineBills.Any(e => e.MedicineBillId == id);
        }
    }
}
