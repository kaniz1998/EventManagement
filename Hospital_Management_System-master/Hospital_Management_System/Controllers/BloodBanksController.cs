using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBanksController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public BloodBanksController(HospitalDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        [Route("GetBloodBanks")]
        public async Task<ActionResult<IEnumerable<BloodBank>>> GetBloodBanks()
        {
            if (_context.BloodBanks == null)
            {
                return NotFound();
            }
            return await _context.BloodBanks.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BloodBank>> GetBloodBank(int id)
        {
            if (_context.BloodBanks == null)
            {
                return NotFound();
            }
            var bloodBank = await _context.BloodBanks.FindAsync(id);

            if (bloodBank == null)
            {
                return NotFound();
            }

            return bloodBank;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloodBank(int id, BloodBank bloodBank)
        {
            if (id != bloodBank.BloodBankID)
            {
                return BadRequest();
            }

            _context.Entry(bloodBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodBankExists(id))
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
        public async Task<ActionResult<BloodBank>> PostBloodBank(BloodBank bloodBank)
        {
            if (_context.BloodBanks == null)
            {
                return Problem("Entity set 'HospitalDbContext.BloodBanks'  is null.");
            }
            _context.BloodBanks.Add(bloodBank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloodBank", new { id = bloodBank.BloodBankID }, bloodBank);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloodBank(int id)
        {
            if (_context.BloodBanks == null)
            {
                return NotFound();
            }
            var bloodBank = await _context.BloodBanks.FindAsync(id);
            if (bloodBank == null)
            {
                return NotFound();
            }

            _context.BloodBanks.Remove(bloodBank);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BloodBankExists(int id)
        {
            return (_context.BloodBanks?.Any(e => e.BloodBankID == id)).GetValueOrDefault();
        }
    }
}
