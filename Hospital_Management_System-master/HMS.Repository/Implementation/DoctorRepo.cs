using HMS.DAL.Generic_Interface;
using HMS.Models;
using HMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//using static HMS.Models.DbModels;

namespace HMS.Repository.Implementation
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly IGenericRepo<Doctor> _docRepo;

        public DoctorRepo(IGenericRepo<Doctor> docRepo)
        {
            this._docRepo = docRepo;
        }
        public IEnumerable<Doctor> GetDoctors()
        {
            try
            {
                return _docRepo.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Doctor GetDoctorById(int id)
        {
            try
            {
                return _docRepo.FindByCondition(x => x.DoctorID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveDoctor(Doctor doctor)
        {
            try
            {
                if (doctor.DoctorID > 0)
                {
                    if (doctor.Image == null)
                    {
                        Doctor existingDoctor = _docRepo.FindByCondition(x => x.DoctorID == doctor.DoctorID).FirstOrDefault();
                        doctor.Image = existingDoctor.Image;
                    }
                    _docRepo.Update(doctor);
                }
                else
                {
                    _docRepo.Create(doctor);
                }
                _docRepo.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteDoctor(int id)
        {
            _docRepo.Delete(id);
            _docRepo.Commit();
        }
    }
}
