using HMS.DAL.Data;
//using HMS.DAL.Migrations;
using HMS.Models;

using HMS.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        //private readonly HospitalDbContext db;
        //public PrescriptionsController(HospitalDbContext db)
        //{
        //    this.db = db;
        //}
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptions()
        //{
        //    try
        //    {
        //        var prs = await db.Prescriptions.ToListAsync();

        //        if (prs == null || prs.Count == 0)
        //        {
        //            return BadRequest("Data Is Empty!!!!!");
        //        }
        //        else
        //        {
        //            return Ok(prs);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}

        //[HttpPost]
        //public async Task<ActionResult> PostPrescriptions(PrescriptionsVM PVM)
        //{
        //    using (var transaction = db.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                Prescription prescriptions = new Prescription
        //                {
        //                    PatientID = PVM.PatientID,
        //                    MedicinID = PVM.MedicinID,
        //                    DoctorID = PVM.DoctorID,
        //                    TestID = PVM.TestID,
        //                    Symptoms = PVM.Symptoms,
        //                    SymptomStartDate = PVM.SymptomStartDate,
        //                    Severity = PVM.Severity,
        //                    Duration = PVM.Duration,
        //                    PrescriptionDate = PVM.PrescriptionDate,
        //                    Dosage = PVM.Dosage,
        //                    Advice = PVM.Advice,
        //                    ProgressNotes = PVM.ProgressNotes,
        //                    NextVisit = PVM.NextVisit,
        //                    AdmissionSuggested = PVM.AdmissionSuggested,
        //                    DiagonesNotes = PVM.DiagonesNotes,
        //                    DiagnosisDate = PVM.DiagnosisDate,
        //                    FollowUpInstructions = PVM.FollowUpInstructions

        //                };
        //                db.Add(prescriptions);
        //                await db.SaveChangesAsync();
        //                transaction.Commit();
        //                return Ok("Data Insert Success!!!!");
        //            }
        //            else
        //            {

        //                return BadRequest(ModelState);
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            transaction.Rollback();
        //            return StatusCode(500, $"An error occurred: {ex.Message}");
        //        }
        //    }
        //}
        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdatePrescriptions(int id, PrescriptionsVM PVM)
        //{
        //    using (var transaction = db.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {

        //                var existingPrescriptions = await db.Prescriptions.FindAsync(id);

        //                if (existingPrescriptions == null)
        //                {
        //                    return NotFound("Prescriptions not found");
        //                }
        //                existingPrescriptions.PatientID = PVM.PatientID;
        //                existingPrescriptions.MedicinID = PVM.MedicinID;
        //                existingPrescriptions.DoctorID = PVM.DoctorID;
        //                existingPrescriptions.TestID = PVM.TestID;
        //                existingPrescriptions.Symptoms = PVM.Symptoms;
        //                existingPrescriptions.SymptomStartDate = PVM.SymptomStartDate;
        //                existingPrescriptions.Severity = PVM.Severity;
        //                existingPrescriptions.Duration = PVM.Duration;
        //                existingPrescriptions.PrescriptionDate = PVM.PrescriptionDate;
        //                existingPrescriptions.Dosage = PVM.Dosage;
        //                existingPrescriptions.Advice = PVM.Advice;
        //                existingPrescriptions.ProgressNotes = PVM.ProgressNotes;
        //                existingPrescriptions.NextVisit = PVM.NextVisit;
        //                existingPrescriptions.AdmissionSuggested = PVM.AdmissionSuggested;
        //                existingPrescriptions.DiagonesNotes = PVM.DiagonesNotes;
        //                existingPrescriptions.DiagnosisDate = PVM.DiagnosisDate;
        //                existingPrescriptions.FollowUpInstructions = PVM.FollowUpInstructions;
        //                await db.SaveChangesAsync();
        //                transaction.Commit();
        //                return Ok("Data Update Success!!!!");
        //            }
        //            else
        //            {
        //                return BadRequest(ModelState);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return StatusCode(500, $"An error occurred: {ex.Message}");
        //        }
        //    }
        //}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeletePrescriptions(int id)
        //{
        //    using (var transaction = db.Database.BeginTransaction())
        //    {
        //        try
        //        {

        //            var existingPrescriptions = await db.Prescriptions.FindAsync(id);

        //            if (existingPrescriptions == null)
        //            {
        //                return NotFound("Prescriptions not found");
        //            }


        //            db.Prescriptions.Remove(existingPrescriptions);
        //            await db.SaveChangesAsync();
        //            transaction.Commit();
        //            return Ok("Data Delete Success!!!!");
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return StatusCode(500, $"An error occurred: {ex.Message}");
        //        }
        //    }
        //}

    }
}
