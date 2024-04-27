using HMS.Models;
using System;
using System.Collections.Generic;

namespace HMS.Repository.Interface
{
    public interface IOtherEmployeeRepo
    {
        IEnumerable<OtherEmployee> GetOtherEmployees();
        OtherEmployee GetOtherEmployeeById(int id);
        void SaveOtherEmployee(OtherEmployee otherEmployee);
        void DeleteOtherEmployee(int id);
    }
}
