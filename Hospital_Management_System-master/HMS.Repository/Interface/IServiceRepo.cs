using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IServiceRepo
    {
        IEnumerable<Service> GetServices();
        Service GetServiceById(int id);
        void SaveService(Service service);
        void DeleteService(int id);
    }
}
