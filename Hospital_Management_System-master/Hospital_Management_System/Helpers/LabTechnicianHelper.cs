using HMS.Models;


namespace Hospital_Management_System.Helpers
{
    public class LabTechnicianHelper
    {
        public LabTechnicianHelper()
        {

        }

        public LabTechnicianHelper(LabTechnician labTechnician)
        {
            this.TechnicianID = labTechnician.TechnicianID;
            this.DepartmentID = labTechnician.DepartmentID;
            this.TechnicianName = labTechnician.TechnicianName;
            this.TechnicianType = labTechnician.TechnicianType;
            this.PhoneNumber = labTechnician.PhoneNumber;

            //// parse TechnicianType from string to enum
            //if (Enum.TryParse(labTechnician.TechnicianType.ToString(), out TechnicianType technicianType))
            //{
            //    this.TechnicianType = technicianType;
            //}

            this.JoinDate = labTechnician.JoinDate;
            this.ResignDate = labTechnician.ResignDate;
            this.employeeStatus = labTechnician.employeeStatus;
            this.Education_Info = labTechnician.Education_Info;
            //this.Departments = labTechnician.Departments;
            //this.Labtest = labTechnician.Labtest.ToList();
        }


        public int TechnicianID { get; set; }
        public int DepartmentID { get; set; }
        public string TechnicianName { get; set; }
        public TechnicianType TechnicianType { get; set; } = default!;
        public DateTime JoinDate { get; set; }
        public DateTime? ResignDate { get; set; }
        public EmployeeStatus employeeStatus { get; set; }
        public IFormFile Image { get; set; }
        public string Education_Info { get; set; }
        public string PhoneNumber { get; set; } = default!;
        //public Department? Departments { get; set; }
        //public List<Test>? Labtest { get; set; }

        public LabTechnician GetLabTechnician()
        {
            LabTechnician labTechnician = new LabTechnician();
            labTechnician.TechnicianID = this.TechnicianID;
            labTechnician.DepartmentID = this.DepartmentID;
            labTechnician.TechnicianName = this.TechnicianName;
            labTechnician.TechnicianType = this.TechnicianType;
            labTechnician.JoinDate = this.JoinDate;
            labTechnician.ResignDate = this.ResignDate;
            labTechnician.employeeStatus = this.employeeStatus;
            labTechnician.Education_Info = this.Education_Info;
            labTechnician.PhoneNumber = this.PhoneNumber;
            //labTechnician.Departments = this.Departments;
            //labTechnician.Labtest = this.Labtest;
            return labTechnician;
        }
    }
}
