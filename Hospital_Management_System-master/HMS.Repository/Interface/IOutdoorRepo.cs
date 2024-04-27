
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IOutdoorRepo
    {
        //Task<Outdoor> GetByIdAsync(int id); //retrieves an `Outdoor` entity by OutdoorID
        IEnumerable<Outdoor> GetById(int id);
        Task<IEnumerable<Outdoor>> GetAllAsync();//Returns all Outdoor record

        Task<IEnumerable<Outdoor>> GetByPatientIdAsync(int patientId);//Retrieves Outdoor record for specific patient

        Task<IEnumerable<Outdoor>> GetByTreatmentTypeAsync(TreatmentType treatmentType);//Get outdoor record based on treatment type (Emergency, Minor Treatment).

        //Task<IEnumerable<Outdoor>> GetOutdoorsByDateRangeAsync(DateTime startDate, DateTime endDate);//retrieve outdoor records within a specified date range.

        Task<IEnumerable<Outdoor>> GetByTreatmentDateAsync(DateTime treatmentDate);//Retrieves Outdoor entities based on the treatment date.

        Task AddAsync(Outdoor outdoor);// Adds a new Outdoor entity 
        Task UpdateAsync(Outdoor outdoor);//Update Outdoor
        Task DeleteAsync(int id);//Delete Outdoor      //necessary?

        
    }
}

