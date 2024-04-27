using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IMedicineGenericRepo
    {
        Task<IEnumerable<MedicineGeneric>> GetAll();
        Task<MedicineGeneric> GetById(int id);
        Task<MedicineGeneric> Insert(MedicineGeneric e);
        Task<MedicineGeneric> Update(MedicineGeneric e);
        Task Delete(int id);
        Task Save();
        Task<MedicineGeneric> GetByNameAsync(string medicineGenericNames);
    }
}
