using HMS.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using HMS.Models;
using Hospital_Management_System.Helpers;

namespace HMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly INurseRepo _nurseRepo;
        private readonly ImageHelper _imageHelper;

        public NursesController(INurseRepo nurseRepo, ImageHelper imageHelper)
        {
            _nurseRepo = nurseRepo;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        [Route("GetNurse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNurse()
        {
            try
            {
                var nurses = _nurseRepo.GetNurses().ToList();
                return Ok(nurses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetNurseById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNurseById(int id)
        {
            try
            {
                Nurse nurse = _nurseRepo.GetNurseById(id);

                if (nurse == null)
                {
                    return NotFound($"Nurse with ID {id} not found.");
                }

                return Ok(nurse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> PostNurse([FromForm] NurseHelper nurseHelper)
        {
            try
            {
                // Handle image upload
                string imagePath = await _imageHelper.SaveImageAsync(nurseHelper.Image);

                if (imagePath == null)
                {
                    return BadRequest("Image upload failed.");
                }

                Nurse nurseToSave = nurseHelper.GetNurse();
                nurseToSave.Image = imagePath;

                // Check if there's an existing nurse with the same ID
                Nurse existingNurse = _nurseRepo.GetNurseById(nurseToSave.NurseID);
                if (existingNurse != null)
                {
                    // Update the nurse's properties
                    existingNurse.DepartmentID = nurseToSave.DepartmentID;
                    existingNurse.NurseName = nurseToSave.NurseName;
                    existingNurse.NurseLevel = nurseToSave.NurseLevel;
                    existingNurse.NurseType = nurseToSave.NurseType;
                    existingNurse.JoinDate = nurseToSave.JoinDate;
                    existingNurse.ResignDate = nurseToSave.ResignDate;
                    existingNurse.employeeStatus = nurseToSave.employeeStatus;
                    existingNurse.Image = nurseToSave.Image;
                    existingNurse.Education_Info = nurseToSave.Education_Info;
                    existingNurse.Department = nurseToSave.Department;

                    _nurseRepo.SaveNurse(existingNurse);
                }
                else
                {
                    // Create a new nurse
                    _nurseRepo.SaveNurse(nurseToSave);
                }

                return Ok(nurseToSave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutNurse(int id, [FromForm] NurseHelper nurseHelper)
        {
            try
            {
                // Handle image upload
                string imagePath = await _imageHelper.SaveImageAsync(nurseHelper.Image);

                Nurse existingNurse = _nurseRepo.GetNurseById(id);

                if (existingNurse == null)
                {
                    return NotFound($"Nurse with ID {id} not found.");
                }

                // Update the existing nurse's properties
                existingNurse.DepartmentID = nurseHelper.DepartmentID;
                existingNurse.NurseName = nurseHelper.NurseName;
                existingNurse.NurseLevel = nurseHelper.NurseLevel;
                existingNurse.NurseType = nurseHelper.NurseType;
                existingNurse.JoinDate = nurseHelper.JoinDate;
                existingNurse.ResignDate = nurseHelper.ResignDate;
                existingNurse.employeeStatus = nurseHelper.employeeStatus;
                existingNurse.Image = imagePath;
                existingNurse.Education_Info = nurseHelper.Education_Info;
                //existingNurse.Department = nurseHelper.Department;

                _nurseRepo.SaveNurse(existingNurse);

                return Ok(existingNurse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteNurse(int id)
        {
            try
            {
                Nurse existingNurse = _nurseRepo.GetNurseById(id);
                if (existingNurse == null)
                {
                    return NotFound($"Nurse with ID {id} not found.");
                }

                return BadRequest("Nurse can't be deleted. Change nurse status instead.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

