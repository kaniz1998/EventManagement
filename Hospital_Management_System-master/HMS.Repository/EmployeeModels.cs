using HMS.DAL.Generic_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository
{
    internal class EmployeeModels : EmployeeBaseClass
    {
        public override int GetId()
        {
            throw new NotImplementedException();
        }

        public class Doctor : EmployeeBaseClass
        {
            // ... (properties from Doctor class)

            // Implementations of methods for Doctor class
            public new static IQueryable<Doctor> GetAll(IGenericRepo<EmployeeBaseClass> repo)
            {
                return repo.FindAll().OfType<Doctor>();
            }

            public new static Doctor GetById(IGenericRepo<EmployeeBaseClass> repo, int id)
            {
                return repo.FindByCondition(entity => entity is Doctor && entity.GetId() == id)
                           .OfType<Doctor>()
                           .FirstOrDefault();
            }

            public override void Create(IGenericRepo<EmployeeBaseClass> repo)
            {
                repo.Create(this);
                repo.Commit();
            }

            public override void Update(IGenericRepo<EmployeeBaseClass> repo)
            {
                repo.Update(this);
                repo.Commit();
            }

            public override void Delete(IGenericRepo<EmployeeBaseClass> repo)
            {
                repo.Delete(GetId());
                repo.Commit();
            }

            public override int GetId()
            {
                throw new NotImplementedException();
            }

            // ... (additional methods if needed)
        }

    }
}
