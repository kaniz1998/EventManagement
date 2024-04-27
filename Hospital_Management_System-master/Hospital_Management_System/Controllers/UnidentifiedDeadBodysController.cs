using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.DAL.Data;
using HMS.Models;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidentifiedDeadBodysController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public UnidentifiedDeadBodysController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/UnidentifiedDeadBodys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidentifiedDeadBody>>> GetUnidentifiedDeadBodies()
        {
            var unidentifiedDeadBodies = await _context.unidentifiedDeadBodies.ToListAsync();
            return Ok(unidentifiedDeadBodies);
        }

        // GET: api/UnidentifiedDeadBodys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidentifiedDeadBody>> GetUnidentifiedDeadBody(int id)
        {
            var unidentifiedDeadBody = await _context.unidentifiedDeadBodies.FindAsync(id);

            if (unidentifiedDeadBody == null)
            {
                return NotFound();
            }

            return Ok(unidentifiedDeadBody);
        }

        // POST: api/UnidentifiedDeadBodys
        [HttpPost]
        public async Task<ActionResult<UnidentifiedDeadBody>> PostUnidentifiedDeadBody(UnidentifiedDeadBody unidentifiedDeadBody)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.unidentifiedDeadBodies.Add(unidentifiedDeadBody);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidentifiedDeadBody", new { id = unidentifiedDeadBody.UnIdenfiedDeadBodyID }, unidentifiedDeadBody);
        }

        // PUT: api/UnidentifiedDeadBodys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidentifiedDeadBody(int id, UnidentifiedDeadBody unidentifiedDeadBody)
        {
            if (id != unidentifiedDeadBody.UnIdenfiedDeadBodyID)
            {
                return BadRequest();
            }

            _context.Entry(unidentifiedDeadBody).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidentifiedDeadBodyExists(id))
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

        // DELETE: api/UnidentifiedDeadBodys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnidentifiedDeadBody>> DeleteUnidentifiedDeadBody(int id)
        {
            var unidentifiedDeadBody = await _context.unidentifiedDeadBodies.FindAsync(id);
            if (unidentifiedDeadBody == null)
            {
                return NotFound();
            }

            _context.unidentifiedDeadBodies.Remove(unidentifiedDeadBody);
            await _context.SaveChangesAsync();

            return unidentifiedDeadBody;
        }

        private bool UnidentifiedDeadBodyExists(int id)
        {
            return _context.unidentifiedDeadBodies.Any(e => e.UnIdenfiedDeadBodyID == id);
        }
    }
}
