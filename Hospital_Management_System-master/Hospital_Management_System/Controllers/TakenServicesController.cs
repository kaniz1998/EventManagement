using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using HMS.DAL.Data;
using HMS.Models;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakenServicesController : ControllerBase
    {
        private readonly HospitalDbContext _db;

        public TakenServicesController(HospitalDbContext db)
        {
            _db = db;
        }

        // GET: api/TakenServices
        [HttpGet]
        public async Task<IActionResult> GetTakenServices()
        {
            var takenServices = await _db.TakenServices.ToListAsync();
            return Ok(takenServices);
        }

        // GET: api/TakenServices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTakenService(int id)
        {
            var takenService = await _db.TakenServices.FindAsync(id);

            if (takenService == null)
            {
                return NotFound();
            }

            return Ok(takenService);
        }
        // POST: api/TakenServices
        [HttpPost]
        public async Task<IActionResult> PostTakenService(TakenService takenService)
        {
            _db.TakenServices.Add(takenService);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTakenService), new { id = takenService.TakenServiceId }, takenService);
        }

        // PUT: api/TakenServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakenService(int id, TakenService takenService)
        {
            if (id != takenService.TakenServiceId)
            {
                return BadRequest();
            }

            _db.Entry(takenService).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakenServiceExists(id))
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



        // DELETE: api/TakenServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMedicineBill(int id)
        {
            try
            {
                var takenService = await _db.TakenServices.FindAsync(id);
                if (takenService == null)
                {
                    return NotFound($"TakenService record with ID {id} not found.");
                }
                return BadRequest("TakenService record can't be deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private bool TakenServiceExists(int id)
        {
            return _db.TakenServices.Any(e => e.TakenServiceId == id);
        }
    }
}
