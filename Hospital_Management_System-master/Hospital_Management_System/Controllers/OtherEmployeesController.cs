using HMS.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Models;
using Hospital_Management_System.Helpers;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherEmployeesController : ControllerBase
    {
        private readonly IOtherEmployeeRepo _otherEmployeeRepo;
        private readonly ImageHelper _imageHelper;

        public OtherEmployeesController(IOtherEmployeeRepo otherEmployeeRepo, ImageHelper imageHelper)
        {
            _otherEmployeeRepo = otherEmployeeRepo;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        [Route("GetOtherEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOtherEmployee()
        {
            try
            {
                var otherEmployees = _otherEmployeeRepo.GetOtherEmployees().ToList();
                return Ok(otherEmployees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetOtherEmployeeById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOtherEmployeeById(int id)
        {
            try
            {
                OtherEmployee otherEmployee = _otherEmployeeRepo.GetOtherEmployeeById(id);

                if (otherEmployee == null)
                {
                    return NotFound($"Other Employee with ID {id} not found.");
                }

                return Ok(otherEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> PostOtherEmployee([FromForm] OtherEmployeeHelper otherEmployeeHelper)
        {
            try
            {
                // Handle image upload
                string imagePath = await _imageHelper.SaveImageAsync(otherEmployeeHelper.Image);

                if (imagePath == null)
                {
                    return BadRequest("Image upload failed.");
                }

                OtherEmployee otherEmployeeToSave = otherEmployeeHelper.GetOtherEmployee();
                otherEmployeeToSave.Image = imagePath;

                _otherEmployeeRepo.SaveOtherEmployee(otherEmployeeToSave);

                return Ok(otherEmployeeToSave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutOtherEmployee(int id, [FromForm] OtherEmployeeHelper otherEmployeeHelper)
        {
            try
            {
                // Handle image upload
                string imagePath = await _imageHelper.SaveImageAsync(otherEmployeeHelper.Image);

                OtherEmployee existingOtherEmployee = _otherEmployeeRepo.GetOtherEmployeeById(id);

                if (existingOtherEmployee == null)
                {
                    return NotFound($"OtherEmployee with ID {id} not found.");
                }

                // Update the existing OtherEmployee's properties
                existingOtherEmployee.OtherEmployeeName = otherEmployeeHelper.OtherEmployeeName;
                //existingOtherEmployee.OtherEmployeeType = otherEmployeeHelper.OtherEmployeeType;
                existingOtherEmployee.JoinDate = otherEmployeeHelper.JoinDate;
                existingOtherEmployee.ResignDate = otherEmployeeHelper.ResignDate;
                existingOtherEmployee.employeeStatus = otherEmployeeHelper.EmployeeStatus;
                existingOtherEmployee.Education_Info = otherEmployeeHelper.Education_Info;
                existingOtherEmployee.Image = imagePath; // Update the image path

                _otherEmployeeRepo.SaveOtherEmployee(existingOtherEmployee);

                return Ok(existingOtherEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteOtherEmployee(int id)
        {
            try
            {
                OtherEmployee existingOtherEmployee = _otherEmployeeRepo.GetOtherEmployeeById(id);
                if (existingOtherEmployee == null)
                {
                    return NotFound($"OtherEmployee with ID {id} not found.");
                }

                _otherEmployeeRepo.DeleteOtherEmployee(id);

                return Ok($"OtherEmployee with ID {id} has been deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
