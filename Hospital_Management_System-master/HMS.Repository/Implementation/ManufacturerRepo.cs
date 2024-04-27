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
    public class ManufacturerRepo : IManufacturerRepo
    {
        private readonly HospitalDbContext _context;
        public ManufacturerRepo(HospitalDbContext context)
        {
            this._context = context;
        }
        public async Task Delete(int id)
        {
            var result = await _context.Manufacturers.FirstOrDefaultAsync(p => p.ManufacturerID == id);
            if (result != null)
            {
                _context.Manufacturers.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Manufacturer>> GetAll()
        {
            IEnumerable<Manufacturer> mgeneric = await _context.Manufacturers.Select(e => new Manufacturer
            {
                ManufacturerID = e.ManufacturerID,
                ManufacturerName = e.ManufacturerName,
            }).ToListAsync();
            return mgeneric;
        }

        public async Task<Manufacturer> GetById(int id)
        {
            Manufacturer? e = await _context.Manufacturers.AsNoTracking()
                         .FirstOrDefaultAsync(e => e.ManufacturerID == id);
            if (e != null)
            {
                Manufacturer manu = new Manufacturer
                {
                    ManufacturerID = e.ManufacturerID,
                    ManufacturerName = e.ManufacturerName,
                };
                return manu;
            }
            return null;
        }

        public async Task<Manufacturer> GetByNameAsync(string manufacturerName)
        {
            Manufacturer? e = await _context.Manufacturers.AsNoTracking()
                         .FirstOrDefaultAsync(e => e.ManufacturerName == manufacturerName);


            if (e != null)
            {
                Manufacturer manu = new Manufacturer
                {
                    ManufacturerID = e.ManufacturerID,
                    ManufacturerName = e.ManufacturerName,


                };
                return manu;
            }
            return null;
        }

        public async Task<Manufacturer> Insert(Manufacturer e)
        {
            Manufacturer manuObj = new Manufacturer();
            if (e != null)
            {
                Manufacturer obj = new Manufacturer()
                {
                    ManufacturerID = e.ManufacturerID,
                    ManufacturerName = e.ManufacturerName,

                };
                await _context.Manufacturers.AddAsync(obj);
                await Save();
                manuObj = await GetById(obj.ManufacturerID);

            }
            return manuObj;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Manufacturer> Update(Manufacturer e)
        {
            var facturer = await _context.Manufacturers.FirstOrDefaultAsync(h => h.ManufacturerID == e.ManufacturerID);
            Manufacturer manu = new Manufacturer();
            if (facturer != null)
            {
                facturer.ManufacturerID = e.ManufacturerID;

                facturer.ManufacturerName = e.ManufacturerName;
            }
            await Save();
            manu = await GetById(facturer.ManufacturerID);
            return manu;
        }
    }
}
