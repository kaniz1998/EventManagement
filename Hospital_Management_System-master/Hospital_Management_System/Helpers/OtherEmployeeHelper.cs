using HMS.Models;

namespace Hospital_Management_System.Helpers
{
    public class OtherEmployeeHelper
    {
        public OtherEmployeeHelper()
        {
        }

        public OtherEmployeeHelper(OtherEmployee otherEmployee)
        {
            EmployeeID = otherEmployee.EmployeeID;
            OtherEmployeeName = otherEmployee.OtherEmployeeName;
            JoinDate = otherEmployee.JoinDate;
            ResignDate = otherEmployee.ResignDate;
            EmployeeStatus = otherEmployee.employeeStatus;
            Education_Info = otherEmployee.Education_Info;
            PhoneNumber = otherEmployee.PhoneNumber;
        }

        public int EmployeeID { get; set; }
        public string OtherEmployeeName { get; set; }
        public string OtherEmployeeType { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? ResignDate { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public IFormFile Image { get; set; }
        public string Education_Info { get; set; }
        public string PhoneNumber { get; set; } = default!;

        public OtherEmployee GetOtherEmployee()
        {
            OtherEmployee otherEmployee = new OtherEmployee();
            otherEmployee.EmployeeID = EmployeeID;
            otherEmployee.OtherEmployeeName = OtherEmployeeName;
            otherEmployee.JoinDate = JoinDate;
            otherEmployee.ResignDate = ResignDate;
            otherEmployee.employeeStatus = EmployeeStatus;
            otherEmployee.Education_Info = Education_Info;
            otherEmployee.PhoneNumber = PhoneNumber;

            return otherEmployee;
        }
    }
}
