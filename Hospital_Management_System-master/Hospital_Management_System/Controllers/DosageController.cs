using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DosageController : ControllerBase
	{
		private readonly HospitalDbContext db;
		public DosageController(HospitalDbContext db)
		{
			this.db = db;
		}
		[HttpGet]
		public IActionResult GetallDosage()
		{
			IQueryable<Dosage> Dosage = db.Dosages.FromSqlRaw("GetDosage").AsQueryable();
			if (Dosage == null)
			{
				return NotFound();
			}

			return Ok(Dosage);
		}
		[HttpGet("{id}")]
		public IActionResult GetDosageById(int id)
		{
			var dos = db.Dosages.FromSqlRaw("SELECT * FROM Dosage WHERE  DosageID = {0}", id).FirstOrDefault();

			if (dos == null)
			{
				return NotFound();
			}

			return Ok(dos);
		}
		[HttpPost]
		public IActionResult InsertDosage([FromForm] Dosage dosage)
		{
			using (var transaction = db.Database.BeginTransaction())
			{
				try
				{
					db.Database.ExecuteSqlRaw("EXEC InsertDosage @Newdosagename={0}",
						dosage.DosageName);

					transaction.Commit();
					return Ok("Dosage inserted successfully.");
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					return BadRequest($"Failed to insert Dosage. Error: {ex.Message}");
				}
			}
		}
		[HttpPut("{id}")]
		public IActionResult UpdateDosage(int id, [FromForm] Dosage dosage)
		{
			using (var transaction = db.Database.BeginTransaction())
			{
				try
				{
					db.Database.ExecuteSqlRaw("EXEC UpdateDosage @Dosageid={0}, @Newdosagename={1}",
						id, dosage.DosageName);

					transaction.Commit();
					return Ok("Dosage updated successfully.");
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					return BadRequest($"Failed to update Dosage. Error: {ex.Message}");
				}
			}
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteDosage(int id)
		{
			var ID = db.Dosages.Find(id);
			if (ID == null)
			{
				return BadRequest($"No {id} Id Found!!!");
			}
			return Ok("You Can Not Delete Test!!!!.");
		}
	}
}
