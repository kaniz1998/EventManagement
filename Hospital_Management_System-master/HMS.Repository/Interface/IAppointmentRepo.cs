using HMS.Models;
using HMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IAppointmentRepo
    {
        /*Task<IEnumerable<Appointment>> GetAllAppointment();*///Returns all appointment record
        Appointment GetAppointmentById(int appointmentID);
        IEnumerable<Appointment> GetAppointmentsForDoctor(int doctorID);
        IEnumerable<AppointmentVM> GetAppointmentsByPatientName(string? patientName, string? patientIdentityNumber);
        IEnumerable<Appointment> GetAppointmentsByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Appointment> GetAppointmentsByType(int appointmentType);
        IEnumerable<Appointment> GetAppointmentsByStatus(int appointmentStatus);
        void AddAppointmentOldPatient(AppointmentVM appointmentOld);
        void AddAppointmentNewPatient(AppointmentVM appointmentNew);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int appointmentID);
    }

}
