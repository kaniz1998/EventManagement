using HMS.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_System.Helpers
{
    public class NurseHelper
    {
        public NurseHelper()
        {

        }

        public NurseHelper(Nurse nurse)
        {
            this.NurseID = nurse.NurseID;
            this.DepartmentID = nurse.DepartmentID;
            this.NurseName = nurse.NurseName;
            this.NurseLevel = nurse.NurseLevel;
            this.NurseType = nurse.NurseType;
            this.JoinDate = nurse.JoinDate;
            this.ResignDate = nurse.ResignDate;
            this.employeeStatus = nurse.employeeStatus;
            this.Education_Info = nurse.Education_Info;
            this.PhoneNumber = nurse.PhoneNumber;
            //this.Department = nurse.Department;
            //this.WardCabins = nurse.WardCabins.ToList();
        }

        public int NurseID { get; set; }
        public int DepartmentID { get; set; }
        public string NurseName { get; set; }
        public NurseLevel NurseLevel { get; set; }
        public NurseType NurseType { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? ResignDate { get; set; }
        public EmployeeStatus employeeStatus { get; set; }

        public string PhoneNumber { get; set; } = default!;
        public IFormFile Image { get; set; }
        public string Education_Info { get; set; }
        //public Department? Department { get; set; }
        //public List<WardCabin> WardCabins { get; set; }

        public Nurse GetNurse()
        {
            Nurse nurse = new Nurse();
            nurse.NurseID = this.NurseID;
            nurse.DepartmentID = this.DepartmentID;
            nurse.NurseName = this.NurseName;
            nurse.NurseLevel = this.NurseLevel;
            nurse.NurseType = this.NurseType;
            nurse.JoinDate = this.JoinDate;
            nurse.ResignDate = this.ResignDate;
            nurse.employeeStatus = this.employeeStatus;
            nurse.Education_Info = this.Education_Info;
            nurse.PhoneNumber = this.PhoneNumber;
            //nurse.Department = this.Department;
            //nurse.WardCabins = this.WardCabins;
            return nurse;
        }




    }
}
