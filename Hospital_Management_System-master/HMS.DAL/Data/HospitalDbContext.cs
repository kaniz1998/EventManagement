using HMS.Models;
using HMS.Models.NumberGeneratorHelper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Data
{
	public class HospitalDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
	{
		public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
		{
		}

		public DbSet<Medicine> Medicines { get; set; }
		public DbSet<MedicineGeneric> MedicineGenerics { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<BloodBank> BloodBanks { get; set; }
		public DbSet<Drawer> Drawers { get; set; }
		public DbSet<DrawerInfo> DrawersInfo { get; set; }
		public DbSet<UnidentifiedDeadBody> unidentifiedDeadBodies { get; set; }
		public DbSet<Morgue> Morgues { get; set; }
		public DbSet<Ambulance> Ambulances { get; set; }
		public DbSet<WasteManagement> WasteManagements { get; set; }
		//public DbSet<Department> Departments { get; set; }
		public DbSet<Department>? Departments { get; set; } = null;
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<PatientRegister> PatientRegisters { get; set; }
		public DbSet<OtherEmployee> OtherEmployees { get; set; }
		public DbSet<Nurse> Nurses { get; set; }
		public DbSet<LabTechnician> LabTechnicians { get; set; }
		//public DbSet<LabEquipment> LabEquipments { get; set; }
		public DbSet<Test> Tests { get; set; }
		public DbSet<Prescription> Prescriptions { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Outdoor> Outdoors { get; set; }
		public DbSet<MedicalRecords> MedicalRecords { get; set; }
		public DbSet<Surgery> Surgeries { get; set; }
		public DbSet<DischargeTransfer> DischargeTransfers { get; set; }
		public DbSet<Bill> Bills { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<WardCabin>? WardCabins { get; set; } = null;
		public DbSet<Symptom> Symptoms { get; set; }
		public DbSet<Advice> Advices { get; set; }
		public DbSet<TestBill> TestBills { get; set; }
		public DbSet<PrescriptionBill> PrescriptionBills { get; set; }
		public DbSet<TakenService> ServiceBills { get; set; }
		public DbSet<AdmissionBill> AdmissionBills { get; set; }
		public DbSet<MedicineBill> MedicineBills { get; set; }
		public DbSet<IndoorPatient> IndoorPatients { get; set; }
		public DbSet<Bed> Beds { get; set; }
		public DbSet<PreoperativeDiagnosis> PreoperativeDiagnoses { get; set; }
		public DbSet<TestReport> TestReports { get; set; }
		public DbSet<NumberCounterRecord> NumberCounterRecords { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<TakenService> TakenServices { get; set; }
		public DbSet<Dosage> Dosages { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			SeedData.SeedDepartments(modelBuilder);
			SeedData.SeedWardCabins(modelBuilder);
			SeedData.SeedPatients(modelBuilder);
			SeedData.SeedDoctors(modelBuilder);
			SeedData.SeedNurses(modelBuilder);
			SeedData.SeedLabTechnicians(modelBuilder);
			SeedData.SeedOtherEmployees(modelBuilder);
			SeedData.SeedServices(modelBuilder);
			SeedData.SeedManufacturer(modelBuilder);
			SeedData.SeedMedicines(modelBuilder);
			SeedData.SeedAdvices(modelBuilder);
			SeedData.SeedSymptoms(modelBuilder);
			SeedData.SeedBeds(modelBuilder);
			SeedData.SeedPreoperativeDiagnosis(modelBuilder);
			SeedData.SeedMedicineGeneric(modelBuilder);
			SeedData.SeedMorgues(modelBuilder);
			SeedData.SeedDrawers(modelBuilder);



			//for auth
			//modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
			//modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
			//modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
			// or for auth


			modelBuilder.Entity<MedicineBill>()
							  .Property("NetPrice")
							 .HasComputedColumnSql("[MedicineCount]*[Price]");

			base.OnModelCreating(modelBuilder);
      
                  modelBuilder.Entity<Morgue>()
                .ToTable("Morgues")
                .HasKey(m => m.MorgueID);

            modelBuilder.Entity<Ambulance>()
               .ToTable("Ambulances")
               .HasKey(a => a.AmbulanceID);
		}

	}
}




//modelBuilder.Entity<PatientRegister>()
// .HasMany(p => p.Prescriptions)
//.WithOne()
// .OnDelete(DeleteBehavior.Restrict);

//modelBuilder.Entity<SurgeryProcedure>()
//.HasOne(sp => sp.Prescription)
//.WithMany()
//.OnDelete(DeleteBehavior.Restrict);