using HMS.DAL.Data;
using HMS.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics.Metrics;
using System.Text;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomsController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        public SymptomsController(HospitalDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Symptom>>> GetAllSymptom()
        {
            var symptomAll = await _context.Symptoms.ToListAsync();
            return Ok(symptomAll);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Symptom>>> GetSymptomById(int id)
        {
            var symptomId=await _context.Symptoms.FirstOrDefaultAsync(x=>x.SymptomId==id);
            return Ok(symptomId);
        }
        [HttpPost]
        public async Task<IActionResult> PostSymptom(Symptom symptom)
        {
             _context.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();
            return Ok(symptom);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSymptom(int id, Symptom symptom)
        {
            var symptomEdit = await _context.Symptoms.FindAsync(id);
            if (symptomEdit != null)
            {
                symptomEdit.SymptomName = symptom.SymptomName; // Update the properties as needed

                await _context.SaveChangesAsync();
                return Ok(symptomEdit);
            }
            else
            {
                return BadRequest("No Id Found");
            }
        }
  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSymptom(int id)
        {
            var symptomDelete = await _context.Symptoms.FindAsync(id);
            _context.Symptoms.Remove(symptomDelete);
            await _context.SaveChangesAsync();
            return Ok("Deleted Successfully!!");
        }
    }
}
