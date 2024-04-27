using HMS.Models;
using HMS.Repository.Interface;
using Hospital_Management_System.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestReportsController : ControllerBase
	{
		private readonly ItesrReport db;
		public TestReportsController(ItesrReport db)
		{
			this.db = db;
		}
		[HttpGet]
		[Route("GetReport")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GetReport()
		{
			try
			{
				var reportdetail = db.GetReport().ToList();
				return Ok(reportdetail);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("GetReport/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GetReportById(int id)
		{
			try
			{
				TestReport report = db.GetReportById(id);

				if (report == null)
				{
					return NotFound($"Report Details with ID {id} not found.");
				}

				return Ok(report);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPost]
		[Route("Insert")]
		public async Task<IActionResult> PostReport([FromForm] TestReportHelper testReportHelper)
		{
			try
			{
				TestReport ReportToSave = testReportHelper.GetTestReport();
				db.SaveReport(ReportToSave);
				return Ok(ReportToSave);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPut]
		[Route("Update/{id}")]
		public async Task<IActionResult> PutReport(int id, [FromForm] TestReportHelper testReportHelper)
		{
			try
			{
				TestReport existinReport = db.GetReportById(id);

				if (existinReport == null)
				{
					return NotFound($"Test Report  with ID {id} not found.");
				}
				existinReport.TestReportID = testReportHelper.TestReportID;
				existinReport.ReportDetailID = testReportHelper.ReportDetailID;
				existinReport.PrescriptionID = testReportHelper.PrescriptionID;
				existinReport.Result = testReportHelper.Result;
				db.SaveReport(existinReport);
				return Ok(existinReport);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpDelete]
		[Route("Delete/{id}")]
		public IActionResult DeleteReport(int id)
		{
			try
			{
				TestReport Existingreport = db.GetReportById(id);
				if (Existingreport == null)
				{
					return NotFound($"Test Report  with ID {id} not found.");
				}
				return BadRequest("Test Report  can't be Deleted. Change doctor status instead.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}