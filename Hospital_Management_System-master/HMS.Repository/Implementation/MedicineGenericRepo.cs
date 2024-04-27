using HMS.DAL.Data;
using HMS.Models;
using HMS.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Implementation
{
    public class MedicineGenericRepo : IMedicineGenericRepo
    {
        private readonly HospitalDbContext _context;
        public MedicineGenericRepo(HospitalDbContext context)
        {
            this._context = context;
        }
        public async Task Delete(int id)
        {
            var result = await _context.MedicineGenerics.FirstOrDefaultAsync(p => p.MedicineGenericID == id);
            if (result != null)
            {
                _context.MedicineGenerics.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MedicineGeneric>> GetAll()
        {
            IEnumerable<MedicineGeneric> mgeneric = await _context.MedicineGenerics.Select(e => new MedicineGeneric
            {
                MedicineGenericID = e.MedicineGenericID,
                MedicineGenericNames = e.MedicineGenericNames,
            }).ToListAsync();
            return mgeneric;
        }

        public async Task<MedicineGeneric> GetById(int id)
        {
            MedicineGeneric? e = await _context.MedicineGenerics.AsNoTracking()
                         .FirstOrDefaultAsync(e => e.MedicineGenericID == id);
            if (e != null)
            {
                MedicineGeneric word = new MedicineGeneric
                {
                    MedicineGenericID = e.MedicineGenericID,

                    MedicineGenericNames = e.MedicineGenericNames,
                };
                return word;
            }
            return null;
        }

        public async Task<MedicineGeneric> GetByNameAsync(string medicineGenericNames)
        {
            MedicineGeneric? e = await _context.MedicineGenerics.AsNoTracking()
                         .FirstOrDefaultAsync(e => e.MedicineGenericNames == medicineGenericNames);


            if (e != null)
            {
                MedicineGeneric word = new MedicineGeneric
                {
                    MedicineGenericID = e.MedicineGenericID,

                    MedicineGenericNames = e.MedicineGenericNames,


                };
                return word;
            }
            return null;
        }

        public async Task<MedicineGeneric> Insert(MedicineGeneric e)
        {
            MedicineGeneric returnObj = new MedicineGeneric();
            if (e != null)
            {
                MedicineGeneric obj = new MedicineGeneric()
                {
                    MedicineGenericID = e.MedicineGenericID,

                    MedicineGenericNames = e.MedicineGenericNames,

                };
                await _context.MedicineGenerics.AddAsync(obj);
                await Save();
                returnObj = await GetById(obj.MedicineGenericID);

            }
            return returnObj;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<MedicineGeneric> Update(MedicineGeneric e)
        {

            var result = await _context.MedicineGenerics.FirstOrDefaultAsync(h => h.MedicineGenericID == e.MedicineGenericID);
            MedicineGeneric returnObj = new MedicineGeneric();
            if (result != null)
            {
                result.MedicineGenericID = e.MedicineGenericID;

                result.MedicineGenericNames = e.MedicineGenericNames;


            }
            await Save();
            returnObj = await GetById(result.MedicineGenericID);
            return returnObj;
        }
    }
}
