using HMS.DAL.Data;
using HMS.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.IO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvicesController : ControllerBase
    {
        private readonly HospitalDbContext db;
        public AdvicesController(HospitalDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetallAdvice()
        {
            IQueryable<Advice> advices = db.Advices.FromSqlRaw("GetAdviceList").AsQueryable();
            if (advices == null)
            {
                return NotFound();
            }

            return Ok(advices);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdviceById(int id)
        {
            var advice = db.Advices.FromSqlRaw("SELECT * FROM Advices WHERE AdviceId = {0}", id).FirstOrDefault();

            if (advice == null)
            {
                return NotFound();
            }

            return Ok(advice);
        }


         [HttpPost]
        public IActionResult InsertAdvice([FromForm] Advice advice)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlRaw("EXEC InsertAdvice @AdviceName={0}",
                        advice.AdviceName);

                    transaction.Commit();
                    return Ok("Advice inserted successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest($"Failed to insert Advice. Error: {ex.Message}");
                }
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdvice(int id, [FromForm] Advice advice)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlRaw("EXEC UpdateAdvice @AdviceId={0}, @NewAdviceName={1}",
                        id, advice.AdviceName);

                    transaction.Commit();
                    return Ok("Advice updated successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest($"Failed to update Advice. Error: {ex.Message}");
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdvice(int id)
        {
            var ID = db.Advices.Find(id);

            db.Database.ExecuteSqlRaw("EXEC DeleteAdvice @AdviceId={0}", id);
            if (ID == null)
            {
                return BadRequest("No Id Found!!!");
            }
            return Ok("Advice deleted successfully.");
        }
    }
}
