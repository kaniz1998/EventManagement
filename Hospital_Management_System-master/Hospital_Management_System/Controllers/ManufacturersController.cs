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
    public class ManufacturersController : ControllerBase
    {
        private readonly HospitalDbContext _db;
        private readonly IManufacturerRepo _iManufacturer;
        public ManufacturersController(IManufacturerRepo iManufacturer, HospitalDbContext db)
        {
            _db = db;
            _iManufacturer = iManufacturer;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var manuList = await _iManufacturer.GetAll();
                return Ok(manuList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Manufacturer>> GetById(int id)
        {
            try
            {
                var manufac = await _iManufacturer.GetById(id);
                if (manufac == null)
                {
                    return NotFound();
                }
                return manufac;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPost("Insert")]
        public async Task<object> Insert([FromBody] Manufacturer obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));
                }

                // Check if the ManufacturerName is empty or null
                if (string.IsNullOrWhiteSpace(obj.ManufacturerName))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "ManufacturerName is required", null));
                }

                // Check if a Manufacturer with the same ManufacturerID already exists
                var manu = await _iManufacturer.GetById(obj.ManufacturerID);
                if (manu != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exists", manu));
                }

                // Check if a Manufacturer with the same name already exists
                var existingManufacturer = await _iManufacturer.GetByNameAsync(obj.ManufacturerName);
                if (existingManufacturer != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "ManufacturerName already exists", existingManufacturer));
                }


                // Additional validation checks for ManufacturerName
                if (!IsValidManufacturerName(obj.ManufacturerName))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Invalid ManufacturerName format", null));
                }

                var returnManu = await _iManufacturer.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Inserted Successfully", returnManu));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        private bool IsValidManufacturerName(string ManufacturerName)
        {
            if (ManufacturerName.Length > 100 || ManufacturerName.Contains("!"))
            {
                return false;
            }

            return true;
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] Manufacturer obj)
        {
            try
            {
                var test = await _iManufacturer.GetById(obj.ManufacturerID);
                if (test == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnManu = await _iManufacturer.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated successfully", returnManu));
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
                var manuDelete = await _iManufacturer.GetById(id);
                if (manuDelete == null)
                {
                    return NotFound();
                }
                await _iManufacturer.Delete(id);
                return Ok("Data Delete Successfully!!");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
    }
}
