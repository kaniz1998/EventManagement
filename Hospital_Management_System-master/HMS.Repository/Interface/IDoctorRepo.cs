using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IDoctorRepo
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctorById(int id);
        void SaveDoctor(Doctor doctor);
        void DeleteDoctor(int id);
    }
}
