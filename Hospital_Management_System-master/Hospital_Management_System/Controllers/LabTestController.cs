using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestController : ControllerBase
    {
        //private readonly HospitalDbContext db;
        //public LabTestController(HospitalDbContext db)
        //{
        //    this.db = db;
        //}
        //[HttpGet]
        //public IActionResult GetallTest()
        //{
        //    IQueryable<Test> labTests = db.Tests.FromSqlRaw("SpAlltest").AsQueryable();
        //    if (labTests == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(labTests);
        //}
        //[HttpPost]
        //public IActionResult InsertTest([FromForm] Test labTest)
        //{
        //    using (var transaction = db.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            db.Database.ExecuteSqlRaw("EXEC SPinsert @Tname={0}, @Pric={1}, @PatientID={2}, @Result={3}, @TechnicianID={4}",
        //                labTest.TestName, labTest.Price, labTest.PatientID, labTest.Result, labTest.TechnicianID);

        //            transaction.Commit();
        //            return Ok("Lab Test inserted successfully.");
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return BadRequest($"Failed to insert test. Error: {ex.Message}");
        //        }
        //    }
        //}


        //[HttpPut("{id}")]
        //public IActionResult UpdateTest(int id, [FromForm] Test labTest)
        //{
        //    using (var transaction = db.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            db.Database.ExecuteSqlRaw("EXEC SPUpdate @id={0}, @Tname={1}, @Pric={2}, @PatientID={3}, @Result={4}, @TechnicianID={5}",
        //                id, labTest.TestName, labTest.Price, labTest.PatientID, labTest.Result, labTest.TechnicianID);

        //            transaction.Commit();
        //            return Ok("Lab Test updated successfully.");
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return BadRequest($"Failed to update Lab test. Error: {ex.Message}");
        //        }
        //    }
        //}


        //[HttpDelete("{id}")]
        //public IActionResult DeleteTest(int id)
        //{
        //    var ID = db.Tests.FirstOrDefault(x => x.TestID == id);

        //    db.Database.ExecuteSqlRaw("EXEC SpDelete @id={0}", ID);
        //    if (ID == null)
        //    {
        //        return BadRequest("No Id Found!!!");
        //    }
        //    return Ok("Lab Test deleted successfully.");
        //}
    }
}
