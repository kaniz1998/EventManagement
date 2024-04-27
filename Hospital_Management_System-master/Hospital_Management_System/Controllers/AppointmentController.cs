using HMS.Repository.Interface;
using Hospital_Management_System.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using HMS.Models.ViewModels;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepo _appointmentRepo;

        public AppointmentController(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        //[HttpGet]
        //[Route("GetAll")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult GetAllAppointments()
        //{
        //    try
        //    {
        //        var appointments = _appointmentRepo.GetAllAsync();
        //        return Ok(appointments);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet]
        [Route("GetAppointmentById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAppointmentById(int id)
        {
            try
            {
                var appointment = _appointmentRepo.GetAppointmentById(id);

                if (appointment == null)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAppointmentsForDoctor/{doctorID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAppointmentsForDoctor(int doctorID)
        {
            try
            {
                var appointments = _appointmentRepo.GetAppointmentsForDoctor(doctorID);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAppointmentsByPatientName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAppointmentsByPatientName(string? patientName, string? patientIdentityNumber)
        {
            try
            {
                var appointments = _appointmentRepo.GetAppointmentsByPatientName(patientName, patientIdentityNumber);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAppointmentsByDateRange/{startDate}/{endDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAppointmentsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var appointments = _appointmentRepo.GetAppointmentsByDateRange(startDate, endDate);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAppointmentsByType/{appointmentType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAppointmentsByType(int appointmentType)
        {
            try
            {
                var appointments = _appointmentRepo.GetAppointmentsByType(appointmentType);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAppointmentsByStatus/{appointmentStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAppointmentsByStatus(int appointmentStatus)
        {
            try
            {
                var appointments = _appointmentRepo.GetAppointmentsByStatus(appointmentStatus);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        //[HttpPost]
        //[Route("CreateAppointment")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult AddAppointment(AppointmentHelper appointmentHelper)
        //{
        //    try
        //    {
        //        if (appointmentHelper.PatientID > 0)
        //        {
        //            // Check if the patient exists in the patientRegister table
        //            // Use the appropriate logic here to check if the patient is old or new
        //            if (string.IsNullOrEmpty(appointmentHelper.PatientIdentityNumber))
        //            {
        //                // If PatientIdentityNumber is null, use AddAppointmentNewPatient
        //                _appointmentRepo.AddAppointmentNewPatient(appointmentHelper.GetAppointmentVM());
        //            }
        //            else
        //            {
        //                // If PatientIdentityNumber is not null, use AddAppointmentOldPatient
        //                _appointmentRepo.AddAppointmentOldPatient(appointmentHelper.GetAppointmentVM());
        //            }
        //        }
        //        else
        //        {
        //            // If PatientID is not provided or is invalid, return BadRequest
        //            return BadRequest("Invalid or missing PatientID.");
        //        }

        //        return Ok("Appointment Created successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        //[HttpPut]
        //[Route("UpdateAppointment/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentHelper appointmentHelper)
        //{
        //    try
        //    {
        //        var existingAppointmentVM = _appointmentRepo.GetAppointmentById(id); // Make sure you retrieve an AppointmentVM

        //        if (existingAppointmentVM == null)
        //        {
        //            return NotFound($"Appointment with ID {id} not found.");
        //        }

        //        appointmentHelper.UpdateAppointmentVM(existingAppointmentVM);

        //        _appointmentRepo.UpdateAppointment(existingAppointmentVM);

        //        return Ok(existingAppointmentVM);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            try
            {
                var existingAppointment = _appointmentRepo.GetAppointmentById(id);

                if (existingAppointment == null)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }
                return BadRequest("Appointment record can't be deleted."); // Provide appropriate logic
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
