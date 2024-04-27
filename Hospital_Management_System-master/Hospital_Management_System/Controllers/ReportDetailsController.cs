using HMS.Models;
using HMS.Repository.Interface;
using Hospital_Management_System.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportDetailsController : ControllerBase
	{
		private readonly IReportDetails db;


		public ReportDetailsController(IReportDetails db)
		{
			this.db = db;

		}

		[HttpGet]
		[Route("GetReportDetails")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GetRepritDetails()
		{
			try
			{
				var reportdetail = db.GetReportDetail().ToList();
				return Ok(reportdetail);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("GetReportDetails/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GetReportdetailsById(int id)
		{
			try
			{
				ReportDetail reportDetail = db.GetReportDetailById(id);

				if (reportDetail == null)
				{
					return NotFound($"Report Details with ID {id} not found.");
				}

				return Ok(reportDetail);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[Route("Insert")]
		public async Task<IActionResult> PostReportdetails([FromForm] ReportDetailsHelper reportDetailsHelper)
		{
			try
			{
				// Handle image upload


				ReportDetail ReportDetailsToSave = reportDetailsHelper.GetReportDetails();


				db.SaveReportDetail(ReportDetailsToSave);

				return Ok(ReportDetailsToSave);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		[Route("Update/{id}")]
		public async Task<IActionResult> PutReportDetails(int id, [FromForm] ReportDetailsHelper reportDetailsHelper)
		{
			try
			{
				ReportDetail existinRdetails = db.GetReportDetailById(id);

				if (existinRdetails == null)
				{
					return NotFound($"Report Details with ID {id} not found.");
				}
				existinRdetails.ReportDetailID = reportDetailsHelper.ReportDetailID;
				existinRdetails.TestID = reportDetailsHelper.TestID;
				existinRdetails.TestName = reportDetailsHelper.TestName;
				existinRdetails.Reference_Value = reportDetailsHelper.Reference_Value;

				db.SaveReportDetail(existinRdetails);

				return Ok(existinRdetails);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public IActionResult DeleteReportDetail(int id)
		{
			try
			{
				ReportDetail ExistingreportDetail = db.GetReportDetailById(id);
				if (ExistingreportDetail == null)
				{
					return NotFound($"Report Details with ID {id} not found.");
				}

				return BadRequest("Report Details can't be Deleted. Change doctor status instead.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}