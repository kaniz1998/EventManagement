using HMS.DAL.Data;

using HMS.DAL.Helper;
using HMS.Models.ViewModels;
using HMS.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly HospitalDbContext _db;
        private readonly IDepartmentRepo _iDepartment;
        public DepartmentsController(IDepartmentRepo iDepartment, HospitalDbContext db)
        {
            _db = db;
            _iDepartment = iDepartment;
        }
        [Authorize(Roles = "IT")]
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var testList = await _iDepartment.GetAll();
                return Ok(testList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Roles = "ABC")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartmentVM>> GetById(int id)
        {
            try
            {
                var result = await _iDepartment.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPost("Insert")]
        public async Task<object> Insert([FromBody] DepartmentVM obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));
                }

                // Check if the DepartmentName is empty or null
                if (string.IsNullOrWhiteSpace(obj.DepartmentName))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "DepartmentName is required", null));
                }

                // Check if a department with the same DepartmentId already exists
                var dep = await _iDepartment.GetById(obj.DepartmentId);
                if (dep != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exists", dep));
                }

                // Check if a department with the same name already exists
                var existingDepartment = await _iDepartment.GetByNameAsync(obj.DepartmentName);
                if (existingDepartment != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "DepartmentName already exists", existingDepartment));
                }


                // Additional validation checks for DepartmentName
                if (!IsValidDepartmentName(obj.DepartmentName))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Invalid DepartmentName format", null));
                }

                var returnObj = await _iDepartment.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Inserted Successfully", returnObj));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Custom method to validate DepartmentName
        private bool IsValidDepartmentName(string departmentName)
        {
            // Add your custom validation logic here
            // Example: Check for length, special characters, or specific naming conventions
            // Return true if valid, false if not
            // Replace this example with your actual validation criteria
            if (departmentName.Length > 100 || departmentName.Contains("!"))
            {
                return false;
            }

            return true;
        }

        [HttpPut("Update")]
        public async Task<object> Update([FromBody] DepartmentVM obj)
        {
            try
            {
                var test = await _iDepartment.GetById(obj.DepartmentId);
                if (test == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnObj = await _iDepartment.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated successfully", returnObj));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var test = await _iDepartment.GetById(id);
                if (test == null)
                {
                    return NotFound();
                }
                await _iDepartment.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
