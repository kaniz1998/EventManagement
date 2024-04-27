using HMS.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using HMS.Models;
using Hospital_Management_System.Helpers;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTechniciansController : ControllerBase
    {
        private readonly ILabTechnicianRepo _labTechnicianRepo;
        private readonly ImageHelper _imageHelper;

        public LabTechniciansController(ILabTechnicianRepo labTechnicianRepo, ImageHelper imageHelper)
        {
            _labTechnicianRepo = labTechnicianRepo;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLabTechnicians()
        {
            try
            {
                var labTechnicians = _labTechnicianRepo.GetLabTechnicians().ToList();
                return Ok(labTechnicians);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetLabTechnicianById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLabTechnicianById(int id)
        {
            try
            {
                LabTechnician labTechnician = _labTechnicianRepo.GetLabTechnicianById(id);

                if (labTechnician == null)
                {
                    return NotFound($"Lab Technician with ID {id} not found.");
                }

                return Ok(labTechnician);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Insert")]
        public async Task<IActionResult> PostLabTechnician([FromForm] LabTechnicianHelper labTechnicianHelper)
        {
            try
            {
                // Handle image upload
                string imagePath = await _imageHelper.SaveImageAsync(labTechnicianHelper.Image);

                if (imagePath == null)
                {
                    return BadRequest("Image upload failed.");
                }

                LabTechnician labTechnicianToSave = labTechnicianHelper.GetLabTechnician();
                labTechnicianToSave.Image = imagePath;

                _labTechnicianRepo.SaveLabTechnician(labTechnicianToSave);

                return Ok(labTechnicianToSave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutLabTechnician(int id, [FromForm] LabTechnicianHelper labTechnicianHelper)
        {
            try
            {
                // Handle image upload
                string imagePath = await _imageHelper.SaveImageAsync(labTechnicianHelper.Image);

                LabTechnician existingLabTechnician = _labTechnicianRepo.GetLabTechnicianById(id);

                if (existingLabTechnician == null)
                {
                    return NotFound($"Lab Technician with ID {id} not found.");
                }

                // Update the existing lab technician's properties
                existingLabTechnician.DepartmentID = labTechnicianHelper.DepartmentID;
                existingLabTechnician.TechnicianName = labTechnicianHelper.TechnicianName;
                existingLabTechnician.TechnicianType = labTechnicianHelper.TechnicianType;
                existingLabTechnician.JoinDate = labTechnicianHelper.JoinDate;
                existingLabTechnician.Image = imagePath; 
                existingLabTechnician.Education_Info = labTechnicianHelper.Education_Info;
                existingLabTechnician.employeeStatus = labTechnicianHelper.employeeStatus;
                //existingLabTechnician.Departments = labTechnicianHelper.Departments;
                //existingLabTechnician.Labtest = labTechnicianHelper.Labtest;

                _labTechnicianRepo.SaveLabTechnician(existingLabTechnician);

                return Ok(existingLabTechnician);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete]
        //[Route("Delete/{id}")]
        //public IActionResult DeleteLabTechnician(int id)
        //{
        //    try
        //    {
        //        LabTechnician existingLabTechnician = _labTechnicianRepo.GetLabTechnicianById(id);
        //        if (existingLabTechnician == null)
        //        {
        //            return NotFound($"Lab Technician with ID {id} not found.");
        //        }

        //        _labTechnicianRepo.DeleteLabTechnician(id);

        //        return Ok($"Lab Technician with ID {id} has been deleted.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteLabTechnician(int id)
        {
            try
            {
                LabTechnician existingLabTechnician = _labTechnicianRepo.GetLabTechnicianById(id);
                if (existingLabTechnician == null)
                {
                    return NotFound($"Lab Technician with ID {id} not found.");
                }

                return BadRequest("Lab Technician can't be deleted. Change lab technician status instead.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
