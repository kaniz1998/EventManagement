using HMS.DAL.Generic_Interface;
using HMS.Models;
using HMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Repository.Implementation
{
    public class LabTechnicianRepo : ILabTechnicianRepo
    {
        private readonly IGenericRepo<LabTechnician> _labTechnicianRepo;

        public LabTechnicianRepo(IGenericRepo<LabTechnician> labTechnicianRepo)
        {
            this._labTechnicianRepo = labTechnicianRepo;
        }

        public IQueryable<LabTechnician> GetLabTechnicians()
        {
            try
            {
                return _labTechnicianRepo.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LabTechnician GetLabTechnicianById(int id)
        {
            try
            {
                return _labTechnicianRepo.FindByCondition(x => x.TechnicianID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveLabTechnician(LabTechnician labTechnician)
        {
            try
            {
                if (labTechnician.TechnicianID > 0)
                {
                    if (labTechnician.Image == null)
                    {
                        LabTechnician existingLabTechnician = _labTechnicianRepo.FindByCondition(x => x.TechnicianID == labTechnician.TechnicianID).FirstOrDefault();
                        labTechnician.Image = existingLabTechnician.Image;
                    }
                    _labTechnicianRepo.Update(labTechnician);
                }
                else
                {
                    _labTechnicianRepo.Create(labTechnician);
                }
                _labTechnicianRepo.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteLabTechnician(int id)
        {
            _labTechnicianRepo.Delete(id);
            _labTechnicianRepo.Commit();
        }
    }
}
