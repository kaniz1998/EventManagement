using HMS.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HMS.Models;
using System;
using System.Linq;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepo _serviceRepo;

        public ServicesController(IServiceRepo serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        [HttpGet]
        [Route("GetServices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetServices()
        {
            try
            {
                var services = _serviceRepo.GetServices().ToList();
                return Ok(services);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetServiceById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetServiceById(int id)
        {
            try
            {
                Service service = _serviceRepo.GetServiceById(id);

                if (service == null)
                {
                    return NotFound($"Service with ID {id} not found.");
                }

                return Ok(service);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateService")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateService([FromBody] Service service)
        {
            try
            {
                if (service == null)
                {
                    return BadRequest("Service data is null.");
                }

                _serviceRepo.SaveService(service);

                return CreatedAtAction(nameof(GetServiceById), new { id = service.ServiceID }, service);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateService/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateService(int id, [FromBody] Service service)
        {
            try
            {
                if (service == null || id != service.ServiceID)
                {
                    return BadRequest("Invalid data provided.");
                }

                var existingService = _serviceRepo.GetServiceById(id);
                if (existingService == null)
                {
                    return NotFound($"Service with ID {id} not found.");
                }

                _serviceRepo.SaveService(service);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteService/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteService(int id)
        {
            try
            {
                var existingService = _serviceRepo.GetServiceById(id);
                if (existingService == null)
                {
                    return NotFound($"Service with ID {id} not found.");
                }

                _serviceRepo.DeleteService(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}