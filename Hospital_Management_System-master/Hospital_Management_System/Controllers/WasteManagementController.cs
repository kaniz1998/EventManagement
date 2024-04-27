using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HMS.DAL.Data;
using HMS.Models;
using Microsoft.EntityFrameworkCore;


namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WasteManagementController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly ILogger<WasteManagementController> _logger;

        public WasteManagementController(HospitalDbContext context, ILogger<WasteManagementController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetWasteManagements()
        {
            try
            {
                var wasteManagements = _context.WasteManagements.FromSqlRaw("EXEC SpAllWasteManagement").ToList();
                return Ok(wasteManagements);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving waste management records.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult PostWasteManagement([FromBody] WasteManagement wasteManagement)
        {
            _context.Database.ExecuteSqlRaw("EXEC InsertWasteManagement @WasteType ={0}, @DisposalDate ={1}, @DisposalMethod ={2}, @Quantity ={3}, @NextScheduleDate ={4}, @ContactNumber ={5}", wasteManagement.WasteType, wasteManagement.DisposalDate, wasteManagement.DisposalMethod, wasteManagement.Quantity, wasteManagement.NextScheduleDate, wasteManagement.ContactNumber);

            return Ok("wasteManagement inserted successfully");
        }

        [HttpPut("{id}")]
        public IActionResult PutWasteManagement(int id, [FromBody] WasteManagement wasteManagement)
        {
            _context.Database.ExecuteSqlRaw("EXEC UpdateWasteManagement @WasteID={0}, @WasteType ={1}, @DisposalDate ={2}, @DisposalMethod ={3}, @Quantity ={4}, @NextScheduleDate ={5}, @ContactNumber ={6}", wasteManagement.WasteID, wasteManagement.WasteType, wasteManagement.DisposalDate, wasteManagement.DisposalMethod, wasteManagement.Quantity, wasteManagement.NextScheduleDate, wasteManagement.ContactNumber);

            return Ok("wasteManagement Updated successfully");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteWasteManagement(int id)
        {
            var ID = _context.WasteManagements.FirstOrDefault(x => x.WasteID == id);

            _context.Database.ExecuteSqlRaw("EXEC DeleteWasteManagement @WasteID={0}", id);
            if (ID != null)
            {
                return Ok("WasteManagement Delete Successfully");
            }
            return BadRequest("WasteManagement Invalid Data");
        }
    }
}

