using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HMS.DAL.Data;
using HMS.Models;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestBillsController : ControllerBase
    {
        private readonly HospitalDbContext _db;

        public TestBillsController(HospitalDbContext db)
        {
            _db = db;
        }

        // GET: api/TestBills
        [HttpGet]
        public async Task<IActionResult> GetTestBills()
        {
            var testBills = await _db.TestBills.ToListAsync();
            return Ok(testBills);
        }

        // GET: api/TestBills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestBill(int id)
        {
            var testBill = await _db.TestBills.FindAsync(id);

            if (testBill == null)
            {
                return NotFound();
            }

            return Ok(testBill);
        }


        // POST: api/TestBills
        [HttpPost]
        public async Task<IActionResult> PostTestBill(TestBill testBill)
        {
            _db.TestBills.Add(testBill);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTestBill), new { id = testBill.TestBillId }, testBill);
        }

        // PUT: api/TestBills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestBill(int id, TestBill testBill)
        {
            if (id != testBill.TestBillId)
            {
                return BadRequest();
            }

            _db.Entry(testBill).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestBillExists(id))
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
        public async Task<ActionResult> DeleteTestBill(int id)
        {
            try
            {
                var testBill = await _db.TestBills.FindAsync(id);
                if (testBill == null)
                {
                    return NotFound($"TestBill record with ID {id} not found.");
                }
                return BadRequest("TestBill record can't be deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool TestBillExists(int id)
        {
            return _db.TestBills.Any(e => e.TestBillId == id);
        }
    }
}
