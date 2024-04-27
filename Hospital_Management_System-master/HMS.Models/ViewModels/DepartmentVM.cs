using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;

namespace HMS.Models.ViewModels
{
    public class DepartmentVM
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required, MaxLength(100)]
        public string DepartmentName { get; set; } = default!;
        public string DepartmentDescription { get; set; } = default!;
        //public  ICollection<Nurse> Nurses { get; set; } = new List<Nurse>();
        //public  ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
        //public  ICollection<WardCabin> WardCabins { get; set; } = new List<WardCabin>();

        //public  ICollection<Test> Tests { get; set; }=new List<Test>();
    }
}
