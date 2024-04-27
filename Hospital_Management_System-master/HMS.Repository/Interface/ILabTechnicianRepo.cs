using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface ILabTechnicianRepo
    {
        IQueryable<LabTechnician> GetLabTechnicians();
        LabTechnician GetLabTechnicianById(int id);
        void SaveLabTechnician(LabTechnician labTechnician);
        void DeleteLabTechnician(int id);
    }

}
