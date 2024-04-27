using HMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IDepartmentRepo
    {
        Task<IEnumerable<DepartmentVM>> GetAll();
        Task<DepartmentVM> GetById(int id);
        Task<DepartmentVM> Insert(DepartmentVM e);
        Task<DepartmentVM> Update(DepartmentVM e);
        Task Delete(int id);
        Task Save();
        Task<DepartmentVM> GetByNameAsync(string departmentName);
    }
}
