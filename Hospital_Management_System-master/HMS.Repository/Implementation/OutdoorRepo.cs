using HMS.DAL.Data;
using HMS.Models;
using HMS.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Implementation
{
    public class OutdoorRepo : IOutdoorRepo
    {
        private readonly HospitalDbContext _dbContext;
        private readonly ILogger<OutdoorRepo> _logger;

        public OutdoorRepo(HospitalDbContext dbContext, ILogger<OutdoorRepo> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        //public async Task<Outdoor?> GetByIdAsync(int id)
        //{
        //    try
        //    {
        //        return await _dbContext
        //                    .Outdoors
        //                    .FromSqlRaw("EXEC GetOutdoorById @Id", new SqlParameter("@Id", id))
        //                    .FirstOrDefaultAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Error while getting Outdoor with ID {id}");
        //        return null;
        //    }
        //}

        public IEnumerable<Outdoor> GetById(int id)
        {
            try
            {
                return _dbContext
                    .Outdoors
                    .FromSqlRaw("EXEC GetOutdoorById @Id", new SqlParameter("@Id", id))
                    .AsEnumerable();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting Outdoor with ID {id}");
                return Enumerable.Empty<Outdoor>();
            }
        }


        public async Task<IEnumerable<Outdoor>> GetAllAsync()
        {
            try
            {
                return await _dbContext
                            .Outdoors
                            .FromSqlRaw("EXEC GetAllOutdoors")
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting all Outdoor records");
                return Enumerable.Empty<Outdoor>();
            }
        }

        public async Task<IEnumerable<Outdoor>> GetByPatientIdAsync(int patientId)
        {
            try
            {
                return await _dbContext
                            .Outdoors
                            .FromSqlRaw("EXEC GetOutdoorsByPatientId @PatientId", new SqlParameter("@PatientId", patientId))
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting Outdoors for Patient ID {patientId}");
                return Enumerable.Empty<Outdoor>(); 
            }
        }

        public async Task<IEnumerable<Outdoor>> GetByTreatmentTypeAsync(TreatmentType treatmentType)
        {
            try
            {
                return await _dbContext
                            .Outdoors
                            .FromSqlRaw("EXEC GetOutdoorsByTreatmentType @TreatmentType", new SqlParameter("@TreatmentType", (int)treatmentType))
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting Outdoors by Treatment Type {treatmentType}");
                return Enumerable.Empty<Outdoor>();
            }
        }

        public async Task<IEnumerable<Outdoor>> GetByTreatmentDateAsync(DateTime treatmentDate)
        {
            try
            {
                return await _dbContext
                            .Outdoors
                            .FromSqlRaw("EXEC GetOutdoorsByTreatmentDate @TreatmentDate", new SqlParameter("@TreatmentDate", treatmentDate))
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting Outdoors by Treatment Date {treatmentDate}");
                return Enumerable.Empty<Outdoor>();
            }
        }

        //outddor by treatment date range add korte hobe
        public async Task AddAsync(Outdoor outdoor)
        {
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@PatientID", outdoor.PatientID),
                    new SqlParameter("@TreatmentType", (int)outdoor.TreatmentType),
                    new SqlParameter("@TreatmentDate", outdoor.TreatmentDate),
                    new SqlParameter("@Remarks", outdoor.Remarks),
                    new SqlParameter("@IsAdmissionRequired", outdoor.IsAdmissionRequired)
                };

                await _dbContext.Database
                    .ExecuteSqlRawAsync("EXEC AddOutdoor @PatientID, @TreatmentType, @TreatmentDate, @Remarks, @IsAdmissionRequired", parameters.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding an Outdoor record");
            }
        }

        public async Task UpdateAsync(Outdoor outdoor)
        {
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@OutdoorID", outdoor.OutdoorID),
                    new SqlParameter("@PatientID", outdoor.PatientID),
                    new SqlParameter("@TreatmentType", (int)outdoor.TreatmentType),
                    new SqlParameter("@TreatmentDate", outdoor.TreatmentDate),
                    new SqlParameter("@Remarks", outdoor.Remarks),
                    new SqlParameter("@IsAdmissionRequired", outdoor.IsAdmissionRequired)
                };

                await _dbContext.Database
                    .ExecuteSqlRawAsync("EXEC UpdateOutdoor @OutdoorID, @PatientID, @TreatmentType, @TreatmentDate, @Remarks, @IsAdmissionRequired", parameters.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating an Outdoor record");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _dbContext.Database
                    .ExecuteSqlRawAsync("EXEC DeleteOutdoor @OutdoorID", new SqlParameter("@OutdoorID", id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting Outdoor with ID {id}");
            }
        }
    }
}




//using HMS.DAL.Data;
//using HMS.Models;
//using HMS.Repository.Interface;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HMS.Repository.Implementation
//{
//    public class OutdoorRepo : IOutdoorRepo
//    {
//        private readonly HospitalDbContext _dbContext;
//        private readonly ILogger<OutdoorRepo> _logger;

//        public OutdoorRepo(HospitalDbContext dbContext, ILogger<OutdoorRepo> logger)
//        {
//            _dbContext = dbContext;
//            _logger = logger;
//        }

//        public async Task<Outdoor> GetByIdAsync(int id)
//        {
//            return await _dbContext
//                        .Outdoors
//                        .FromSqlRaw("EXEC GetOutdoorById @Id", new SqlParameter("@Id", id))
//                        .FirstOrDefaultAsync();
//        }

//        public async Task<IEnumerable<Outdoor>> GetAllAsync()
//        {
//            return await _dbContext
//                        .Outdoors
//                        .FromSqlRaw("EXEC GetAllOutdoors")
//                        .ToListAsync();
//        }

//        public async Task<IEnumerable<Outdoor>> GetByPatientIdAsync(int patientId)
//        {
//            return await _dbContext
//                        .Outdoors
//                        .FromSqlRaw("EXEC GetOutdoorsByPatientId @PatientId", new SqlParameter("@PatientId", patientId))
//                        .ToListAsync();
//        }

//        public async Task<IEnumerable<Outdoor>> GetByTreatmentTypeAsync(TreatmentType treatmentType)
//        {
//            return await _dbContext
//                        .Outdoors
//                        .FromSqlRaw("EXEC GetOutdoorsByTreatmentType @TreatmentType", new SqlParameter("@TreatmentType", (int)treatmentType))
//                        .ToListAsync();
//        }

//        public async Task<IEnumerable<Outdoor>> GetByTreatmentDateAsync(DateTime treatmentDate)
//        {
//            return await _dbContext
//                        .Outdoors
//                        .FromSqlRaw("EXEC GetOutdoorsByTreatmentDate @TreatmentDate", new SqlParameter("@TreatmentDate", treatmentDate))
//                        .ToListAsync();
//        }

//        //public async Task<IEnumerable<Outdoor>> GetByDoctorIdAsync(int doctorId)
//        //{
//        //    return await _dbContext
//        //                .Outdoors
//        //                .FromSqlRaw("EXEC GetOutdoorsByDoctorId @DoctorId", new SqlParameter("@DoctorId", doctorId))
//        //                .ToListAsync();
//        //}

//        public async Task AddAsync(Outdoor outdoor)
//        {
//            var parameters = new List<SqlParameter>
//        {
//            new SqlParameter("@PatientID", outdoor.PatientID),
//            new SqlParameter("@TreatmentType", (int)outdoor.TreatmentType),
//            new SqlParameter("@TreatmentDate", outdoor.TreatmentDate),
//            new SqlParameter("@TicketNumber", outdoor.TicketNumber),
//            //new SqlParameter("@DoctorID", outdoor.DoctorID),
//            new SqlParameter("@Remarks", outdoor.Remarks),
//            new SqlParameter("@IsAdmissionRequired", outdoor.IsAdmissionRequired)
//        };

//            await _dbContext.Database
//                .ExecuteSqlRawAsync("EXEC AddOutdoor @PatientID, @TreatmentType, @TreatmentDate, @TicketNumber, @Remarks, @IsAdmissionRequired", parameters
//                .ToArray());
//        }

//        public async Task UpdateAsync(Outdoor outdoor)
//        {
//            var parameters = new List<SqlParameter>
//        {
//            new SqlParameter("@OutdoorID", outdoor.OutdoorID),
//            new SqlParameter("@PatientID", outdoor.PatientID),
//            new SqlParameter("@TreatmentType", (int)outdoor.TreatmentType),
//            new SqlParameter("@TreatmentDate", outdoor.TreatmentDate),
//            new SqlParameter("@TicketNumber", outdoor.TicketNumber),
//            //new SqlParameter("@BillID", outdoor.BillID),
//            //new SqlParameter("@DoctorID", outdoor.DoctorID),
//            new SqlParameter("@Remarks", outdoor.Remarks),
//            new SqlParameter("@IsAdmissionRequired", outdoor.IsAdmissionRequired)
//        };

//            await _dbContext.Database
//                .ExecuteSqlRawAsync("EXEC UpdateOutdoor @OutdoorID, @PatientID, @TreatmentType, @TreatmentDate, @TicketNumber, @Remarks, @IsAdmissionRequired", parameters
//                .ToArray());
//        }

//        public async Task DeleteAsync(int id)
//        {
//            await _dbContext.Database
//                .ExecuteSqlRawAsync("EXEC DeleteOutdoor @OutdoorID", new SqlParameter("@OutdoorID", id));
//        }
//    }
//}
