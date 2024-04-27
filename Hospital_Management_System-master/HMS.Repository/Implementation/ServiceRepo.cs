using HMS.DAL.Generic_Interface;
using HMS.Models;
using HMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Implementation
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly IGenericRepo<Service> _serviceRepo;

        public ServiceRepo(IGenericRepo<Service> serviceRepo)
        {
            this._serviceRepo = serviceRepo;
        }


        public Service GetServiceById(int id)
        {
            try
            {
                return _serviceRepo.FindByCondition(x => x.ServiceID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Service> GetServices()
        {
            try
            {
                return _serviceRepo.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveService(Service service)
        {
            try
            {
                if (service.ServiceID > 0)
                {
                    if (service == null)
                    {
                        Service existingService = _serviceRepo.FindByCondition(x => x.ServiceID == service.ServiceID).FirstOrDefault();

                    }
                    _serviceRepo.Update(service);
                }
                else
                {
                    _serviceRepo.Create(service);
                }
                _serviceRepo.Commit();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteService(int id)
        {
            _serviceRepo.Delete(id);
            _serviceRepo.Commit();
        }
    }
}
