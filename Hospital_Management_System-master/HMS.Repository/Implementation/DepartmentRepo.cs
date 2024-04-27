using HMS.DAL.Data;
using HMS.Models.ViewModels;
using HMS.Models;
using HMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repository.Implementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly HospitalDbContext _context;
        public DepartmentRepo(HospitalDbContext context)
        {
            this._context = context;
        }
        public async Task Delete(int id)
        {
            var result = await _context.Departments.FirstOrDefaultAsync(p => p.DepartmentId == id);
            if (result != null)
            {
                _context.Departments.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DepartmentVM>> GetAll()
        {
            IEnumerable<DepartmentVM> listOfLabTest = await _context.Departments.Select(e => new DepartmentVM
            {
                DepartmentId = e.DepartmentId,

                DepartmentName = e.DepartmentName,
                DepartmentDescription = e.DepartmentDescription

            }).ToListAsync();
            return listOfLabTest;
        }

        public async Task<DepartmentVM> GetById(int id)
        {

            //if need null
            Department? e = await _context.Departments.AsNoTracking()
                         .FirstOrDefaultAsync(e => e.DepartmentId == id);


            if (e != null)
            {
                DepartmentVM word = new DepartmentVM
                {
                    DepartmentId = e.DepartmentId,

                    DepartmentName = e.DepartmentName,
                    DepartmentDescription = e.DepartmentDescription

                };
                return word;
            }
            return null;




        }

        public async Task<DepartmentVM> GetByNameAsync(string departmentName)
        {
            //return  _context.Departments.FirstOrDefault(d=>d.DepartmentName == departmentName);
            //if need null
            Department? e = await _context.Departments.AsNoTracking()
                         .FirstOrDefaultAsync(e => e.DepartmentName == departmentName);


            if (e != null)
            {
                DepartmentVM word = new DepartmentVM
                {
                    DepartmentId = e.DepartmentId,

                    DepartmentName = e.DepartmentName,
                    DepartmentDescription = e.DepartmentDescription

                };
                return word;
            }
            return null;


        }

        public async Task<DepartmentVM> Insert(DepartmentVM e)
        {
            DepartmentVM returnObj = new DepartmentVM();
            if (e != null)
            {
                Department obj = new Department()
                {
                    DepartmentId = e.DepartmentId,

                    DepartmentName = e.DepartmentName,
                    DepartmentDescription = e.DepartmentDescription

                };
                await _context.Departments.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.DepartmentId);

            }
            return returnObj;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<DepartmentVM> Update(DepartmentVM e)
        {
            var result = await _context.Departments.FirstOrDefaultAsync(h => h.DepartmentId == e.DepartmentId);
            DepartmentVM returnObj = new DepartmentVM();
            if (result != null)
            {
                result.DepartmentId = e.DepartmentId;

                result.DepartmentName = e.DepartmentName;
                result.DepartmentDescription = e.DepartmentDescription;

            }
            await Save();
            returnObj = await GetById(result.DepartmentId);
            return returnObj;
        }
    }
}
