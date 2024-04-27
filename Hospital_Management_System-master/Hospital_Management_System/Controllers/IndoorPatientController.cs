using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndoorPatientController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public IndoorPatientController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndoorPatient>>> GetAllIndoorPatient()
        {
            return await _context.IndoorPatients.FromSqlRaw("GetAllIndoorPatients").ToListAsync();
        }

        // GET: api/Patient Id

        [HttpGet("{id}")]
        public async Task<ActionResult<IndoorPatient>> GetIndoorPatientByID(int id)
        {
            var patient = await _context.IndoorPatients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        //POST: api/Patient

        [HttpPost]
        public async Task<ActionResult<IndoorPatient>> CreatePatient(IndoorPatient IndoorPatient)
        {


            _context.Database.ExecuteSqlRaw("EXEC InsertIndoorPatient @ReferredBy={0}, @BedID={1},@InsuranceInfo={2},@AdmissionNotes={3},@IsDead={4}, @PatientID={5},@MedicalRecordsID={6}, @NIDnumber={7},@AdmissionDate={8},@DateOfBirth={9},@EmergencyContact={10},@BloodType={11},@IsTransferred={12}", IndoorPatient.ReferredBy, IndoorPatient.BedID, IndoorPatient.InsuranceInfo, IndoorPatient.AdmissionNotes, IndoorPatient.IsDead, IndoorPatient.PatientID, IndoorPatient.MedicalRecordsID, IndoorPatient.NIDnumber, IndoorPatient.AdmissionDate, IndoorPatient.DateOfBirth, IndoorPatient.EmergencyContact, IndoorPatient.BloodType, IndoorPatient.IsTransferred);
            await _context.SaveChangesAsync();
            return Ok(IndoorPatient);
        }

        //PUT: api/Patient

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, IndoorPatient IndoorPatient)
        {


            _context.Database.ExecuteSqlRaw("EXEC UpdateIndoorPatient  @IndoorPatientID={0}, @ReferredBy={1}, @BedID={2},@InsuranceInfo={3},@AdmissionNotes={4},@IsDead={5}, @PatientID={6},@MedicalRecordsID={7}, @NIDnumber={8},@AdmissionDate={9},@DateOfBirth={10},@EmergencyContact={11},@BloodType={12},@IsTransferred={13}", IndoorPatient.IndoorPatientID, IndoorPatient.ReferredBy, IndoorPatient.BedID, IndoorPatient.InsuranceInfo, IndoorPatient.AdmissionNotes, IndoorPatient.IsDead, IndoorPatient.PatientID, IndoorPatient.MedicalRecordsID, IndoorPatient.NIDnumber, IndoorPatient.AdmissionDate, IndoorPatient.DateOfBirth, IndoorPatient.EmergencyContact, IndoorPatient.BloodType, IndoorPatient.IsTransferred);
            await _context.SaveChangesAsync();
            return Ok(IndoorPatient);
        }

        // DELETE: api/Patient 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndoorPatient(int id)
        {


            var Indoorpatient = await _context.IndoorPatients.FindAsync(id);
            _context.Database.ExecuteSqlRaw("EXEC DeleteIndoorPatient @IndoorPatientID={0}", id);
            if (Indoorpatient == null)
            {
                return BadRequest("IndoorPatient id is invalid");
            }
            return Ok("data deleted successfully");
        }
    }
}
