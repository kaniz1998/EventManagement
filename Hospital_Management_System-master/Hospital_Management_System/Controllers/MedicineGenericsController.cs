using HMS.DAL.Data;
using HMS.DAL.Helper;
using HMS.Models;
using HMS.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineGenericsController : ControllerBase
    {
        private readonly HospitalDbContext _db;
        private readonly IMedicineGenericRepo _iMedicineGeneric;
        public MedicineGenericsController(IMedicineGenericRepo iMedicineGeneric, HospitalDbContext db)
        {
            _db = db;
            _iMedicineGeneric = iMedicineGeneric;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var testList = await _iMedicineGeneric.GetAll();
                return Ok(testList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MedicineGeneric>> GetById(int id)
        {
            try
            {
                var result = await _iMedicineGeneric.GetById(id);
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
        public async Task<object> Insert([FromBody] MedicineGeneric obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));
                }

                // Check if the MedicineGenericNames is empty or null
                if (string.IsNullOrWhiteSpace(obj.MedicineGenericNames))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "MedicineGenericNames is required", null));
                }

                // Check if a MedicineGeneric with the same MedicineGenericID already exists
                var dep = await _iMedicineGeneric.GetById(obj.MedicineGenericID);
                if (dep != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exists", dep));
                }

                // Check if a MedicineGeneric with the same name already exists
                var existingDepartment = await _iMedicineGeneric.GetByNameAsync(obj.MedicineGenericNames);
                if (existingDepartment != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "MedicineGenericNames already exists", existingDepartment));
                }


                // Additional validation checks for MedicineGenericNames
                if (!IsValidMedicineGenericNames(obj.MedicineGenericNames))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Invalid MedicineGenericNames format", null));
                }

                var returnObj = await _iMedicineGeneric.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Inserted Successfully", returnObj));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        private bool IsValidMedicineGenericNames(string medicineGenericNames)
        {
            if (medicineGenericNames.Length > 100 || medicineGenericNames.Contains("!"))
            {
                return false;
            }

            return true;
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] MedicineGeneric obj)
        {
            try
            {
                var test = await _iMedicineGeneric.GetById(obj.MedicineGenericID);
                if (test == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnObj = await _iMedicineGeneric.Update(obj);
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
                var test = await _iMedicineGeneric.GetById(id);
                if (test == null)
                {
                    return NotFound();
                }
                await _iMedicineGeneric.Delete(id);
                return Ok("Data Delete Successfully!!");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }

    }
}
