using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediciensController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public MediciensController(HospitalDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetAllMedicine()
        {
            var medicines = await _context.Medicines.FromSqlRaw("EXEC SpGetAllMedicine").ToListAsync();
            return Ok(medicines);
        }
        [HttpGet("{id}")]
        public ActionResult GetMedicineById(int id)
        {
            var idParameter = new SqlParameter("@id", id);

            IQueryable<Medicine> medicine = _context.Medicines
                .FromSqlRaw("EXEC SphMedicineById @id", idParameter)
                .AsQueryable();

            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }


        [HttpPost]
        [Route("PostMedicine")]
        public async Task<ActionResult<Medicine>> PostMedicine([FromForm] Medicine medicine)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw("EXEC SpPtAllMedicine @MedicineName={0},@Weight={1},  @MedicineType={2},@DosageForms={3}, @ExpireDate={4},@Quantity={5},@SellPrice={6},@Discount={7},@MedicineGenericID={8},@ManufacturerID ={9}"
                    ,
                         medicine.MedicineName, medicine.Weight, medicine.MedicineType, medicine.DosageForms, medicine.ExpireDate, medicine.Quantity, medicine.SellPrice, medicine.Discount, medicine.MedicineGenericID, medicine.ManufacturerID);

                    transaction.Commit();
                    return Ok("Medicine inserted successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest($"Failed to insert Medicine. Error: {ex.Message}");
                }
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Medicine>> UpdateMedicine(int id, [FromForm] Medicine medicine)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw("EXEC SpUdateMedicine @id={0}, @MedicineName={1},@Weight={2},  @MedicineType={3},@DosageForms={4}, @ExpireDate={5},@Quantity={6},@SellPrice={7},@Discount={8},@MedicineGenericID={9},@ManufacturerID ={10}"
                    ,
                        id, medicine.MedicineName, medicine.Weight, medicine.MedicineType, medicine.DosageForms, medicine.ExpireDate, medicine.Quantity, medicine.SellPrice, medicine.Discount, medicine.MedicineGenericID, medicine.ManufacturerID);

                    transaction.Commit();
                    return Ok("Medicine Update successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest($"Failed to Update Medicine. Error: {ex.Message}");
                }
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            var medicine = await _context.PatientRegisters.FindAsync(id);
            _context.Database.ExecuteSqlRaw("EXEC SpDeMedicine @id={0}", id);
            if (medicine == null)
            {
                return BadRequest("Medicine id is invalid");
            }
            return Ok("data deleted successfully");
        }


    }
}
