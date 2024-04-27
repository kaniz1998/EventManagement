using HMS.DAL.Generic_Interface;
using HMS.Models;
using HMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HMS.Repository.Implementation
{
    public class NurseRepo : INurseRepo
    {
        private readonly IGenericRepo<Nurse> _nurseRepo;

        public NurseRepo(IGenericRepo<Nurse> nurseRepo)
        {
            this._nurseRepo = nurseRepo;
        }

        public IEnumerable<Nurse> GetNurses()
        {
            try
            {
                return _nurseRepo.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Nurse GetNurseById(int id)
        {
            try
            {
                return _nurseRepo.FindByCondition(x => x.NurseID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveNurse(Nurse nurse)
        {
            try
            {
                if (nurse.NurseID > 0)
                {
                    if (nurse.Image == null)
                    {
                        Nurse existingNurse = _nurseRepo.FindByCondition(x => x.NurseID == nurse.NurseID).FirstOrDefault();
                        nurse.Image = existingNurse.Image;
                    }
                    _nurseRepo.Update(nurse);
                }
                else
                {
                    _nurseRepo.Create(nurse);
                }
                _nurseRepo.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteNurse(int id)
        {
            _nurseRepo.Delete(id);
            _nurseRepo.Commit();
        }
    }
}
