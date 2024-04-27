using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Models;
using HMS.DAL.Data;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MorgueController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public MorgueController(HospitalDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Morgue>>> GetMorgues()
        {
            return await _context.Morgues.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Morgue>> GetMorgue(int id)
        {
            var morgue = await _context.Morgues.FindAsync(id);

            if (morgue == null)
            {
                return NotFound();
            }

            return morgue;
        }
        [HttpPost]
        public async Task<ActionResult<Morgue>> CreateMorgue(Morgue morgue)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC InsertMorgue  @MorgueName={0}, @Capacity={1},@IsolationCapability={2}", morgue.MorgueName, morgue.Capacity, morgue.IsolationCapability);
            return Ok("Morgue inserted successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMorgue(int id, Morgue morgue)
        {

            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateMorgue  @MorgueID={0}, @MorgueName={1},@Capacity={2},@IsolationCapability={3}", morgue.MorgueID, morgue.MorgueName, morgue.Capacity, morgue.IsolationCapability);
            return Ok("Morgue Update successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMorgue(int id)
        {
            var ID = await _context.Morgues.FirstOrDefaultAsync(x => x.MorgueID == id);
            //await _context.Database.ExecuteSqlRawAsync("EXEC DeleteMorgue @MorgueID={0}", ID);
            if (ID == null)
            {
                return BadRequest(" Morgue Data Not Found!!!");
            }
            return Ok("Morgue Data You Can't Delete.");
        }
    }
}
