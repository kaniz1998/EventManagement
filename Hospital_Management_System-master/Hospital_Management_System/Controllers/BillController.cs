using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly HospitalDbContext _db;

        public BillController(HospitalDbContext db)
        {
            _db = db;
        }

        // GET: api/Bill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            return await _db.Bills.ToListAsync();
        }

        // GET: api/Bill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(int id)
        {
            var bill = await _db.Bills.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }

        // POST: api/Bill
        [HttpPost]
        public async Task<ActionResult<Bill>> PostBill(Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Bills.Add(bill);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetBill", new { id = bill.BillId }, bill);
        }

        // PUT: api/Bill/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill(int id, Bill bill)
        {
            if (id != bill.BillId)
            {
                return BadRequest("Invalid request");
            }

            _db.Entry(bill).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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

        // DELETE: api/Bill/5
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteBill(int id)
        {
            try
            {
                var bill = await _db.Bills.FindAsync(id);
                if (bill == null)
                {
                    return NotFound($"Bills record with ID {id} not found.");
                }
                return BadRequest("Bills record can't be deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool BillExists(int id)
        {
            return _db.Bills.Any(e => e.BillId == id);
        }
    }
}
