using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly HospitalDbContext db;
		public TestController(HospitalDbContext db)
		{
			this.db = db;
		}
		[HttpGet]
		public IActionResult GetallATest()
		{
			IQueryable<Test> tests = db.Tests.FromSqlRaw("GetTestsList").AsQueryable();
			if (tests == null)
			{
				return NotFound();
			}

			return Ok(tests);
		}

		[HttpGet("{id}")]
		public IActionResult GetTestById(int id)
		{
			var test = db.Tests.FromSqlRaw("SELECT * FROM Tests WHERE  TestID = {0}", id).FirstOrDefault();

			if (test == null)
			{
				return NotFound();
			}

			return Ok(test);
		}
		[HttpPost]
		public IActionResult InsertTest([FromForm] Test test)
		{
			using (var transaction = db.Database.BeginTransaction())
			{
				try
				{
					db.Database.ExecuteSqlRaw("EXEC InsertTest @Testname={0},@Testype={1},@price={2}",
						test.TestName, test.TestType, test.Price);

					transaction.Commit();
					return Ok("TEST inserted successfully.");
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					return BadRequest($"Failed to insert TEST. Error: {ex.Message}");
				}
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateTest(int id, [FromForm] Test test)
		{
			using (var transaction = db.Database.BeginTransaction())
			{
				try
				{
					db.Database.ExecuteSqlRaw("EXEC UpdateTest @testid={0},@NewTestname={1},@Testype={2},@price={3}",
						id, test.TestName, test.TestType, test.Price);

					transaction.Commit();
					return Ok("Test updated successfully.");
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					return BadRequest($"Failed to update Test Error: {ex.Message}");
				}
			}
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteTest(int id)
		{
			var ID = db.Tests.Find(id);
			if (ID == null)
			{
				return BadRequest($"No {id} Id Found!!!");
			}
			return Ok("You Can Not Delete Test!!!!.");
		}
	}
}
