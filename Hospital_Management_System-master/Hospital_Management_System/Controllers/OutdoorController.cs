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
    public class OutdoorController : ControllerBase
    {
        private readonly IOutdoorRepo _outdoorRepo;

        public OutdoorController(IOutdoorRepo outdoorRepo)
        {
            _outdoorRepo = outdoorRepo;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllOutdoors()
        {
            try
            {
                //var outdoors = _outdoorRepo.GetAllAsync().ToList();
                var outdoors = _outdoorRepo.GetAllAsync();
                return Ok(outdoors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetOutdoorById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOutdoorById(int id)
        {
            try
            {
                var outdoor = _outdoorRepo.GetById(id);

                if (outdoor == null)
                {
                    return NotFound($"Outdoor record with ID {id} not found.");
                }

                return Ok(outdoor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> PostOutdoor([FromBody] OutdoorHelper outdoorHelper)
        {
            try
            {
                Outdoor outdoorToSave = outdoorHelper.GetOutdoor();

                await _outdoorRepo.AddAsync(outdoorToSave);

                return Ok(outdoorToSave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutOutdoor(int id, [FromBody] OutdoorHelper outdoorHelper)
        {
            try
            {
                var existingOutdoor = _outdoorRepo.GetById(id).FirstOrDefault();

                if (existingOutdoor == null)
                {
                    return NotFound($"Outdoor record with ID {id} not found.");
                }

                outdoorHelper.UpdateOutdoor(existingOutdoor);

                await _outdoorRepo.UpdateAsync(existingOutdoor);

                return Ok(existingOutdoor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteOutdoor(int id)
        {
            try
            {
                var existingOutdoor = _outdoorRepo.GetById(id).FirstOrDefault();

                if (existingOutdoor == null)
                {
                    return NotFound($"Outdoor record with ID {id} not found.");
                }

                _outdoorRepo.DeleteAsync(id);

                return Ok($"Outdoor record with ID {id} has been deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpPut]
        //[Route("Update/{id}")]
        //public async Task<IActionResult> PutOutdoor(int id, [FromBody] OutdoorHelper outdoorHelper)
        //{
        //    try
        //    {
        //        //Outdoor existingOutdoor = await _outdoorRepo.GetByIdAsync(id);
        //        Outdoor existingOutdoor = await _outdoorRepo.GetById(id);

        //        if (existingOutdoor == null)
        //        {
        //            return NotFound($"Outdoor record with ID {id} not found.");
        //        }

        //        outdoorHelper.UpdateOutdoor(existingOutdoor);

        //        await _outdoorRepo.UpdateAsync(existingOutdoor);

        //        return Ok(existingOutdoor);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        //[HttpDelete]
        //[Route("Delete/{id}")]
        //public IActionResult DeleteOutdoor(int id)
        //{
        //    try
        //    {
        //        var existingOutdoor = _outdoorRepo.GetByIdAsync(id);

        //        if (existingOutdoor == null)
        //        {
        //            return NotFound($"Outdoor record with ID {id} not found.");
        //        }
        //        return BadRequest("Outdoor record can't be deleted.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
