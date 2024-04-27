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
    public class OtherEmployeeRepo : IOtherEmployeeRepo
    {
        private readonly IGenericRepo<OtherEmployee> _otherEmployeeRepo;

        public OtherEmployeeRepo(IGenericRepo<OtherEmployee> otherEmployeeRepo)
        {
            this._otherEmployeeRepo = otherEmployeeRepo;
        }

        public IEnumerable<OtherEmployee> GetOtherEmployees()
        {
            try
            {
                return _otherEmployeeRepo.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OtherEmployee GetOtherEmployeeById(int id)
        {
            try
            {
                return _otherEmployeeRepo.FindByCondition(x => x.EmployeeID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveOtherEmployee(OtherEmployee otherEmployee)
        {
            try
            {
                if (otherEmployee.EmployeeID > 0)
                {
                    // Handle updating existing record
                    _otherEmployeeRepo.Update(otherEmployee);
                }
                else
                {
                    // Handle creating a new record
                    _otherEmployeeRepo.Create(otherEmployee);
                }

                _otherEmployeeRepo.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteOtherEmployee(int id)
        {
            _otherEmployeeRepo.Delete(id);
            _otherEmployeeRepo.Commit();
        }
    }
}
