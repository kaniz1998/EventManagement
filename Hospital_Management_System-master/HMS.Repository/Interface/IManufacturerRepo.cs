using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IManufacturerRepo
    {
        Task<IEnumerable<Manufacturer>> GetAll();
        Task<Manufacturer> GetById(int id);
        Task<Manufacturer> Insert(Manufacturer e);
        Task<Manufacturer> Update(Manufacturer e);
        Task Delete(int id);
        Task Save();
        Task<Manufacturer> GetByNameAsync(string manufacturerName);
    }
}
