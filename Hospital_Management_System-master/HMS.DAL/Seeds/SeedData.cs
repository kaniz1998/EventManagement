
using HMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace HMS.DAL.Data
{
    public static class SeedData
    {
        public static void SeedDepartments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "Neurology",
                    DepartmentDescription = "It is concerned with disorders and diseases of the nervous system"
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Paediatrics",
                    DepartmentDescription = "The branch of medicine dealing with children and their diseases."
                }
            );
        }

        public static void SeedWardCabins(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WardCabin>().HasData(
                new WardCabin
                {
                    WardID = 1,
                    WardCabinName = "Neuro Care",
                    DepartmentID = 1,
                },
                new WardCabin
                {
                    WardID = 2,
                    WardCabinName = "Child Care",
                    DepartmentID = 2,
                }
            );
        }

        public static void SeedPatients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientRegister>().HasData(
                new PatientRegister
                {
                    PatientID = 1,
                    PatientName = "Sultana begum",
                    Gender = Gender.Female,
                    Address = "dhaka",
                    Email = "am@gmail.com",
                    PhoneNumber = "12345678",
                },
                new PatientRegister
                {
                    PatientID = 2,
                    PatientName = "Azman Mollah",
                    Gender = Gender.Male,
                    Address = "Sirajgonj",
                    Email = "az@gmail.com",
                    PhoneNumber = "1233454",
                }
            );
        }

        public static void SeedDoctors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    DoctorID = 1,
                    DoctorName = "Pipul Rahman",
                    DepartmentID = 1,
                    Specialization = "Cardiologist",
                    Doctortype = (doctortype)1,
                    JoinDate = DateTime.Parse("2023-01-15"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)1,
                    Education_Info = "MD in Cardiology from DMC University",
                    PhoneNumber = "01917123456",
                    Image = "doctor1.jpg"
                },
                new Doctor
                {
                    DoctorID = 2,
                    DoctorName = "Ass Pina",
                    DepartmentID = 2,
                    Specialization = "Orthopedic Surgeon",
                    Doctortype = (doctortype)4,
                    JoinDate = DateTime.Parse("2023-02-20"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)1,
                    Education_Info = "MD in Orthopedics from ABC University",
                    PhoneNumber = "01517123456",
                    Image = "doctor2.jpg"
                }
            );
        }

        public static void SeedNurses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nurse>().HasData(
                new Nurse
                {
                    NurseID = 1,
                    NurseName = "Sharmin Jahan",
                    DepartmentID = 1,
                    NurseType = (NurseType)1,
                    JoinDate = DateTime.Parse("2023-03-10"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)1,
                    Education_Info = "Bachelor of Science in Nursing",
                    PhoneNumber = "01317123456",
                    Image = "nurse1.jpg"
                },
                new Nurse
                {
                    NurseID = 2,
                    NurseName = "Hafsa khatun",
                    DepartmentID = 2,
                    NurseType = (NurseType)2,
                    JoinDate = DateTime.Parse("2023-04-05"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)2,
                    Education_Info = "Licensed Practical Nurse Certification",
                    PhoneNumber = "01817123456",
                    Image = "nurse2.jpg"
                }
            );
        }

        public static void SeedLabTechnicians(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LabTechnician>().HasData(
                new LabTechnician
                {
                    TechnicianID = 1,
                    TechnicianName = "valsun choudhury",
                    DepartmentID = 1,
                    TechnicianType = (TechnicianType)1,
                    JoinDate = DateTime.Parse("2023-05-15"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)1,
                    Education_Info = "Bachelor of Science in Medical Technology",
                    PhoneNumber = "01617123456",
                    Image = "labtech1.jpg"
                },
                new LabTechnician
                {
                    TechnicianID = 2,
                    TechnicianName = "Robin mia",
                    DepartmentID = 2,
                    TechnicianType = (TechnicianType)2,
                    JoinDate = DateTime.Parse("2023-06-10"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)2,
                    Education_Info = "Certified Laboratory Technician",
                    PhoneNumber = "01917123456",
                    Image = "labtech2.jpg"
                }
            );
        }

        public static void SeedOtherEmployees(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OtherEmployee>().HasData(
                new OtherEmployee
                {
                    EmployeeID = 1,
                    OtherEmployeeName = "abul mia",
                    OtherEmployeeType = (OtherEmployeeType)2,
                    JoinDate = DateTime.Parse("2023-07-20"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)1,
                    Education_Info = "JSC",
                    PhoneNumber = "01917123456",
                    Image = "wordboy1.jpg"
                },
                new OtherEmployee
                {
                    EmployeeID = 2,
                    OtherEmployeeName = "ataur",
                    OtherEmployeeType = (OtherEmployeeType)6,
                    JoinDate = DateTime.Parse("2023-08-05"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)2,
                    Education_Info = "SSC",
                    PhoneNumber = "01517123456",
                    Image = "driver1.jpg"
                }
            );
        }
        public static void SeedServices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service { ServiceID = 1, ServiceName = "Bed charge", ServiceCharge = 500 },
                new Service { ServiceID = 2, ServiceName = "Cabin charge", ServiceCharge = 1500 },
                new Service { ServiceID = 3, ServiceName = "ICU charge", ServiceCharge = 3000 },
                new Service { ServiceID = 4, ServiceName = "Oxygen charge (per liter)", ServiceCharge = 120 },
                new Service { ServiceID = 5, ServiceName = "Food (per time)", ServiceCharge = 200 },
                new Service { ServiceID = 6, ServiceName = "Wound Dressing", ServiceCharge = 100 },
                new Service { ServiceID = 7, ServiceName = "Injection Pushing", ServiceCharge = 50 },
                new Service { ServiceID = 8, ServiceName = "Outdoor Doctor Visit", ServiceCharge = 500 },
                new Service { ServiceID = 9, ServiceName = "Indoor Doctor Visit (Assistant Professor)", ServiceCharge = 800 },
                new Service { ServiceID = 10, ServiceName = "Indoor Doctor Visit (Associate Professor)", ServiceCharge = 1200 },
                new Service { ServiceID = 11, ServiceName = "Indoor Doctor Visit (Professor)", ServiceCharge = 1500 },
                new Service { ServiceID = 12, ServiceName = "Room Cleaning", ServiceCharge = 100 },
                new Service { ServiceID = 13, ServiceName = "Patient Cleaning", ServiceCharge = 50 },
                new Service { ServiceID = 14, ServiceName = "Physical Therapy", ServiceCharge = 300 },
                new Service { ServiceID = 15, ServiceName = "Ambulance charge", ServiceCharge = 1000 },
                new Service { ServiceID = 16, ServiceName = "Morgue charge", ServiceCharge = 500 },
                new Service { ServiceID = 17, ServiceName = "Cloth Fee (Hospital Gown)", ServiceCharge = 100 },
                new Service { ServiceID = 18, ServiceName = "Orthopedic Device charge (crutches, wheelchair)", ServiceCharge = 250 },
                new Service { ServiceID = 19, ServiceName = "Pathological Sample Collection Fee (from Bed/Home)", ServiceCharge = 200 },
                new Service { ServiceID = 20, ServiceName = "Counseling fee", ServiceCharge = 400 },
                new Service { ServiceID = 21, ServiceName = "Rehabilitation fee", ServiceCharge = 400 },
				new Service { ServiceID = 22, ServiceName = "Admission Charge", ServiceCharge = 500 }
			);
        }
        public static void SeedAdvices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advice>().HasData(
            new Advice { AdviceId = 1, AdviceName = "Eat Healthy" },
            new Advice { AdviceId = 2, AdviceName = "Exercise Regularly" },
            new Advice { AdviceId = 3, AdviceName = "Get Enough Sleep" },
            new Advice { AdviceId = 4, AdviceName = "Stay Hydrated" },
            new Advice { AdviceId = 5, AdviceName = "Manage Stress" }
            );
        }
        public static void SeedSymptoms(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Symptom>().HasData(
            new Symptom { SymptomId = 1, SymptomName = "Fever" },
            new Symptom { SymptomId = 2, SymptomName = "Cough" },
            new Symptom { SymptomId = 3, SymptomName = "Headache" },
            new Symptom { SymptomId = 4, SymptomName = "Sore Throat" }
            );
        }
        public static void SeedBeds(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bed>().HasData(
            new Bed { BedID = 1, BedNumber = "W101", IsOccupied = true, WardCabinID = 1 },
            new Bed { BedID = 2, BedNumber = "W102", IsOccupied = true, WardCabinID = 1 },
            new Bed { BedID = 3, BedNumber = "W103", IsOccupied = true, WardCabinID = 1 },
            new Bed { BedID = 4, BedNumber = "C101", IsOccupied = true, WardCabinID = 2 },
            new Bed { BedID = 5, BedNumber = "C102", IsOccupied = true, WardCabinID = 2 }
            );
        }
        public static void SeedPreoperativeDiagnosis(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PreoperativeDiagnosis>().HasData(
            new PreoperativeDiagnosis { PreoperativeDiagnosisID = 1, PreoperativeDiagnosisName = "Hypertension" },
            new PreoperativeDiagnosis { PreoperativeDiagnosisID = 2, PreoperativeDiagnosisName = "Diabetes" },
            new PreoperativeDiagnosis { PreoperativeDiagnosisID = 3, PreoperativeDiagnosisName = "Obesity" },
            new PreoperativeDiagnosis { PreoperativeDiagnosisID = 4, PreoperativeDiagnosisName = "Heart Disease" },
            new PreoperativeDiagnosis { PreoperativeDiagnosisID = 5, PreoperativeDiagnosisName = "Kidney Disease" }
            );
        }
        public static void SeedMedicineGeneric(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineGeneric>().HasData(
            new MedicineGeneric { MedicineGenericID = 1, MedicineGenericNames = "Atorvastatin" },
            new MedicineGeneric { MedicineGenericID = 2, MedicineGenericNames = "Rosuvastatin" },
            new MedicineGeneric { MedicineGenericID = 3, MedicineGenericNames = "Metformin Hydrochloride" },
            new MedicineGeneric { MedicineGenericID = 4, MedicineGenericNames = "linagliptin & Metformin" },
            new MedicineGeneric { MedicineGenericID = 5, MedicineGenericNames = "Olmisertan " }
            );
        }
        public static void SeedManufacturer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasData(
            new Manufacturer { ManufacturerID = 1, ManufacturerName = "Square Pharmaceuticals Ltd " },
            new Manufacturer { ManufacturerID = 2, ManufacturerName = "Incepta Pharmaceutical Ltd" },
            new Manufacturer { ManufacturerID = 3, ManufacturerName = "Beximco Pharmaceuticals Ltd" },
            new Manufacturer { ManufacturerID = 4, ManufacturerName = "Opsonin Pharma Ltd" },
            new Manufacturer { ManufacturerID = 5, ManufacturerName = "Renata Ltd" },
            new Manufacturer { ManufacturerID = 6, ManufacturerName = "Healthcare Pharmaceuticals Ltd" },
            new Manufacturer { ManufacturerID = 7, ManufacturerName = "Radient Pharmaceuticals Ltd" },
            new Manufacturer { ManufacturerID = 8, ManufacturerName = "Eskayef Pharmaceuticals Ltd" },
            new Manufacturer { ManufacturerID = 9, ManufacturerName = "ACME Laboratories Ltd" },
            new Manufacturer { ManufacturerID = 10, ManufacturerName = "Aristopharma Ltd" }
            );
        }

        public static void SeedMedicines(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
            new Medicine{
                MedicineID = 1,
                MedicineName = "Napa",
                Weight = "500mg",
                MedicineType = MedicineType.Allopathy,
                DosageForms = DosageForms.Tablet,
                ExpireDate = new DateTime(2025, 02, 02),
                Quantity = 522,
                SellPrice = 5612.00M,
                Discount = 50.00M,
                MedicineGenericID = 1,
                ManufacturerID = 1,
            },
            new Medicine
            {
                MedicineID = 2,
                MedicineName = "Seclo",
                Weight = "20mg",
                MedicineType = MedicineType.Allopathy,
                DosageForms = DosageForms.Tablet,
                ExpireDate = new DateTime(2025, 03, 02),
                Quantity = 522,
                SellPrice = 5612.00M,
                Discount = 50.00M,
                MedicineGenericID = 2,
                ManufacturerID = 2,
            },
            new Medicine
            {
                MedicineID = 3,
                MedicineName = "Napa Extra",
                Weight = "20mg",
                MedicineType = MedicineType.Allopathy,
                DosageForms = DosageForms.Tablet,
                ExpireDate = new DateTime(2025, 03, 02),
                Quantity = 522,
                SellPrice = 5612.00M,
                Discount = 50.00M,
                MedicineGenericID = 2,
                ManufacturerID = 2,
            }           
            );

        }

		public static void SeedMorgues(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Morgue>().HasData(
				new Morgue
				{
					MorgueID = 1,
					MorgueName = "Morgue-1",
					Capacity = 50,
					IsolationCapability = true
				},
				new Morgue
				{
					MorgueID = 2,
					MorgueName = "Morgue-2",
					Capacity = 100,
					IsolationCapability = false
				}
			);
		}
		public static void SeedDrawers(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Drawer>().HasData(
				new Drawer
				{
					DrawerID = 1,
					DrawerNo = "Drawer-001",
					DrawerCondition = DrawerCondition.Clean,
					IsOccupied = false,
					MorgueID = 1
				},
				new Drawer
				{
					DrawerID = 2,
					DrawerNo = "Drawer-002",
					DrawerCondition = DrawerCondition.Dirty,
					IsOccupied = true,
					MorgueID = 2 
				}
			);
		}

	}
}
