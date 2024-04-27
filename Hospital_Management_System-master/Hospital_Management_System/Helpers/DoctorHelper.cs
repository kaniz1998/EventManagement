using HMS.Models;

namespace Hospital_Management_System.Helpers
{
    public class DoctorHelper
    {
        public DoctorHelper()
        {

        }

        public DoctorHelper(Doctor doctor)
        {
            this.DoctorID = doctor.DoctorID;
            this.DepartmentID = doctor.DepartmentID;
            this.DoctorName = doctor.DoctorName;
            this.Specialization = doctor.Specialization;
            this.doctortype = doctor.Doctortype;
            this.JoinDate = doctor.JoinDate;
            this.ResignDate = doctor.ResignDate;
            this.Education_Info = doctor.Education_Info;
            this.employeeStatus = doctor.employeeStatus;
            this.PhoneNumber = doctor.PhoneNumber;

            //this.Department = doctor.Department;
            //this.Prescriptions = doctor.Prescriptions.ToList();
            //this.Appointments = doctor.Appointments.ToList();
            //this.Surgeries = doctor.Surgeries.ToList();
        }

        public int DoctorID { get; set; }
        public int DepartmentID { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public doctortype doctortype { get; set; } = default!;
        public DateTime JoinDate { get; set; }
        public DateTime? ResignDate { get; set; }
        public IFormFile Image { get; set; }
        public string Education_Info { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public EmployeeStatus employeeStatus { get; set; }
        //public Department? Department { get; set; }
        //public List<Prescriptions>? Prescriptions { get; set; }
        //public List<Appointment>? Appointments { get; set; }
        //public List<SurgeryProcedure>? Surgeries { get; set; }

        public Doctor GetDoctor()
        {
            Doctor doctor = new Doctor();
            doctor.DoctorID = this.DoctorID;
            doctor.DepartmentID = this.DepartmentID;
            doctor.DoctorName = this.DoctorName;
            doctor.Specialization = this.Specialization;
            this.doctortype = doctor.Doctortype;
            doctor.JoinDate = this.JoinDate;
            doctor.employeeStatus = this.employeeStatus;
            doctor.Education_Info = this.Education_Info;
            doctor.PhoneNumber = this.PhoneNumber;
            //doctor.Department = this.Department;
            //doctor.Prescriptions = this.Prescriptions;
            //doctor.Appointments = this.Appointments;
            //doctor.Surgeries = this.Surgeries;
            return doctor;
        }


    }
}
