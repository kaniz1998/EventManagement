using HMS.DAL.Generic_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository
{
    public abstract class EmployeeBaseClass
    {
        // Common properties
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; } = default!;
        public string WorkShift { get; set; } = default!;
        public DateTime JoinDate { get; set; }
        public string Image { get; set; } = default!;
        public string Education_Info { get; set; } = default!;

        public abstract int GetId();

        public static IQueryable<EmployeeBaseClass> GetAll(IGenericRepo<EmployeeBaseClass> repo)
        {
            return repo.FindAll();
        }

        public static EmployeeBaseClass GetById(IGenericRepo<EmployeeBaseClass> repo, int id)
        {
            return repo.FindByCondition(entity => entity.GetId() == id).FirstOrDefault();
        }
        public virtual void Create(IGenericRepo<EmployeeBaseClass> repo)
        {
            repo.Create(this);
            repo.Commit();
        }

        public virtual void Update(IGenericRepo<EmployeeBaseClass> repo)
        {
            repo.Update(this);
            repo.Commit();
        }

        public virtual void Delete(IGenericRepo<EmployeeBaseClass> repo)
        {
            repo.Delete(GetId());
            repo.Commit();
        }


    }
}
