using HMS.DAL.Data;
using HMS.Models;
using HMS.Models.ViewModels;
using HMS.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace HMS.Repository
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly HospitalDbContext _dbContext;
        private readonly ILogger<AppointmentRepo> _logger;

        public AppointmentRepo(HospitalDbContext dbContext, ILogger<AppointmentRepo> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Appointment GetAppointmentById(int appointmentID)
        {
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@AppointmentID", appointmentID)
                };

                return _dbContext.Appointments
                    .FromSqlRaw("EXEC GetAppointmentById @AppointmentID", parameters.ToArray())
                    .AsEnumerable()
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting appointment with ID: {appointmentID}");
                return null;
            }
        }

        public IEnumerable<Appointment> GetAppointmentsForDoctor(int doctorID)
        {
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@DoctorID", doctorID),
                    //new SqlParameter("@DoctorName", doctorName)
                };

                return _dbContext.Appointments
                    .FromSqlRaw("EXEC GetAppointmentsForDoctor @DoctorID", parameters.ToArray())
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting appointments for doctor with ID: {doctorID}");
                return Enumerable.Empty<Appointment>();
            }
        }

        //public IEnumerable<AppointmentVM> GetAppointmentsByPatientName(string? patientName, string? patientIdentityNumber)
        //{
        //    try
        //    {
        //        var parameters = new List<SqlParameter>
        //    {
        //        new SqlParameter("@PatientName", patientName),
        //        new SqlParameter("@PatientIdentityNumber", patientIdentityNumber)
        //    };

        //        var sql = "EXEC GetAppointmentsByPatientName @PatientName, @PatientIdentityNumber";

        //        using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
        //        {
        //            command.CommandText = sql;
        //            command.Parameters.AddRange(parameters.ToArray());
        //            command.CommandType = CommandType.StoredProcedure;

        //            _dbContext.Database.OpenConnection();

        //            using (var result = command.ExecuteReader())
        //            {
        //                var appointmentVMs = new List<AppointmentVM>();
        //                while (result.Read())
        //                {
        //                    var appointmentVM = new AppointmentVM
        //                    {
        //                        AppointmentID = Convert.ToInt32(result["AppointmentID"]),
        //                        PatientName = result["PatientName"].ToString(),
        //                        PatientIdentityNumber = result["PatientIdentityNumber"].ToString(),
        //                        Gender = Convert.ToInt32(result["Gender"]),
        //                        PhoneNumber = result["PhoneNumber"].ToString(),
        //                        DoctorID = Convert.ToInt32(result["DoctorID"]),
        //                        AppointmentType = (HMS.Models.ViewModels.AppointmentType)Enum.Parse(typeof(HMS.Models.ViewModels.AppointmentType), result["AppointmentType"].ToString()),
        //                        AppointmentDate = Convert.ToDateTime(result["AppointmentDate"]),
        //                        AppointmentStatus = (HMS.Models.ViewModels.AppointmentStatus)Enum.Parse(typeof(HMS.Models.ViewModels.AppointmentStatus), result["AppointmentStatus"].ToString())

        //                    };
        //                    appointmentVMs.Add(appointmentVM);
        //                }
        //                return appointmentVMs;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Error while getting appointments for patient: {patientName}");
        //        return Enumerable.Empty<AppointmentVM>();
        //    }
        //    finally
        //    {
        //        _dbContext.Database.CloseConnection();
        //    }
        //}

        // Helper method for mapping Appointment to AppointmentVM
        //private AppointmentVM MapAppointmentVMToAppointment(AppointmentVM appointmentVM)
        //{
        //    return new AppointmentVM
        //    {
        //        AppointmentID = appointmentVM.AppointmentID,
        //        PatientName = appointmentVM.PatientName,
        //        PatientIdentityNumber = appointmentVM.PatientIdentityNumber,
        //        PhoneNumber = appointmentVM.PhoneNumber,
        //        Gender = appointmentVM.Gender,
        //        PatientID = appointmentVM.PatientID,
        //        DoctorID = appointmentVM.DoctorID,
        //        AppointmentType = (Models.ViewModels.AppointmentType)appointmentVM.AppointmentType,
        //        AppointmentDate = appointmentVM.AppointmentDate,
        //        AppointmentStatus = (Models.ViewModels.AppointmentStatus)appointmentVM.AppointmentStatus
        //    };
        //}
        //public IEnumerable<AppointmentVM> GetAppointmentsByPatientName(string? patientName, string? patientIdentityNumber)
        //{
        //    // Call the stored procedure using Entity Framework
        //    var appointments = _dbContext.Appointments.FromSqlRaw("EXEC GetAppointmentsByPatientName @PatientName={0}, @PatientIdentityNumber={1}", patientName, patientIdentityNumber);

        //    // Map the database entities to AppointmentVM view models
        //    var appointmentVMs = new List<AppointmentVM>();
        //    foreach (var appointment in appointments)
        //    {
        //        var appointmentvm = MapAppointmentVMToAppointment(appointmentVM);
        //        //var appointmentVM = new AppointmentVM
        //        //{
        //        //    AppointmentID = appointment.AppointmentID,
        //        //    PatientName = appointment.PatientName,
        //        //    PatientIdentityNumber = appointment.PatientIdentityNumber,
        //        //    PhoneNumber = appointment.PhoneNumber,
        //        //    Gender = appointment.Gender,
        //        //    PatientID = appointment.PatientID,
        //        //    DoctorID = appointment.DoctorID,
        //        //    AppointmentType = (Models.ViewModels.AppointmentType)appointment.AppointmentType,
        //        //    AppointmentDate = appointment.AppointmentDate,
        //        //    AppointmentStatus = (Models.ViewModels.AppointmentStatus)appointment.AppointmentStatus

        //        //};

        //        appointmentVMs.Add(appointmentvm);
        //    }

        //    return appointmentVMs;
        //}

        private AppointmentVM MapAppointmentToAppointmentVM(Appointment appointment)
        {
            return new AppointmentVM
            {
                AppointmentID = appointment.AppointmentID,
                //PatientName = appointment.PatientName,  // Map the PatientName property
                //PatientIdentityNumber = appointment.PatientIdentityNumber,  // Map the PatientIdentityNumber property
                //PhoneNumber = appointment.PhoneNumber,  // Map the PhoneNumber property
                //Gender = appointment.Gender,
                PatientID = appointment.PatientID,
                DoctorID = appointment.DoctorID,
                AppointmentType = (Models.ViewModels.AppointmentType)appointment.AppointmentType,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentStatus = (Models.ViewModels.AppointmentStatus)appointment.AppointmentStatus
            };
        }

        public IEnumerable<AppointmentVM> GetAppointmentsByPatientName(string? patientName, string? patientIdentityNumber)
        {
            // Call the stored procedure using Entity Framework
            var appointments = _dbContext.Appointments.FromSqlRaw("EXEC GetAppointmentsByPatientName @PatientName={0}, @PatientIdentityNumber={1}", patientName, patientIdentityNumber);

            // Map the database entities to AppointmentVM view models using the mapping method
            var appointmentVMs = new List<AppointmentVM>();
            foreach (var appointment in appointments)
            {
                var appointmentVM = MapAppointmentToAppointmentVM(appointment);
                appointmentVMs.Add(appointmentVM);
            }

            return appointmentVMs;
        }




        public IEnumerable<Appointment> GetAppointmentsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

                return _dbContext.Appointments
                    .FromSqlRaw("EXEC GetAppointmentsByDateRange @StartDate, @EndDate", parameters.ToArray())
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting appointments between {startDate} and {endDate}");
                return Enumerable.Empty<Appointment>();
            }
        }

        public IEnumerable<Appointment> GetAppointmentsByType(int appointmentType)
        {
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@AppointmentType", appointmentType)
            };

                return _dbContext.Appointments
                    .FromSqlRaw("EXEC GetAppointmentsByType @AppointmentType", parameters.ToArray())
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting appointments of type: {appointmentType}");
                return Enumerable.Empty<Appointment>();
            }
        }

        public IEnumerable<Appointment> GetAppointmentsByStatus(int appointmentStatus)
        {
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@AppointmentStatus", appointmentStatus)
            };

                return _dbContext.Appointments
                    .FromSqlRaw("EXEC GetAppointmentsByStatus @AppointmentStatus", parameters.ToArray())
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting appointments with status: {appointmentStatus}");
                return Enumerable.Empty<Appointment>();
            }
        }

        public void AddAppointmentOldPatient(AppointmentVM appointmentOld)
        {
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@PatientIdentityNumber", appointmentOld.PatientIdentityNumber),
                new SqlParameter("@DoctorID", appointmentOld.DoctorID),
                new SqlParameter("@AppointmentType", (int)appointmentOld.AppointmentType),
                new SqlParameter("@AppointmentDate", appointmentOld.AppointmentDate),
                new SqlParameter("@AppointmentStatus", (int)appointmentOld.AppointmentStatus)
            };

                _dbContext.Database.ExecuteSqlRaw("EXEC AddAppointmentOldPatient @PatientIdentityNumber, @DoctorID, @AppointmentType, @AppointmentDate, @AppointmentStatus", parameters.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding appointment for old patient");
            }
        }

        public void AddAppointmentNewPatient(AppointmentVM appointmentNew)
        {
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@PhoneNumber", appointmentNew.PhoneNumber),
                new SqlParameter("@PatientName", appointmentNew.PatientName),
                new SqlParameter("@Gender", appointmentNew.Gender),
                new SqlParameter("@DoctorID", appointmentNew.DoctorID),
                new SqlParameter("@AppointmentType", (int)appointmentNew.AppointmentType),
                new SqlParameter("@AppointmentDate", appointmentNew.AppointmentDate),
                new SqlParameter("@AppointmentStatus", (int)appointmentNew.AppointmentStatus)
            };

                _dbContext.Database.ExecuteSqlRaw("EXEC AddAppointmentNewPatient @PhoneNumber, @PatientName, @Gender, @DoctorID, @AppointmentType, @AppointmentDate, @AppointmentStatus", parameters.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding appointment for new patient");
            }
        }

        public void UpdateAppointment(Appointment appointment)
        {
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@AppointmentID", appointment.AppointmentID),
                new SqlParameter("@AppointmentStatus", (int)appointment.AppointmentStatus),
                new SqlParameter("@DoctorID", appointment.DoctorID),
                new SqlParameter("@AppointmentDate", appointment.AppointmentDate)
            };

                _dbContext.Database.ExecuteSqlRaw("EXEC UpdateAppointment @AppointmentID, @AppointmentStatus, @DoctorID, @AppointmentDate", parameters.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while updating appointment with ID: {appointment.AppointmentID}");
            }
        }

        public void DeleteAppointment(int appointmentID)
        {
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@AppointmentID", appointmentID)
            };

                _dbContext.Database.ExecuteSqlRaw("EXEC DeleteAppointment @AppointmentID", parameters.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting appointment with ID: {appointmentID}");
            }
        }
    }


}
