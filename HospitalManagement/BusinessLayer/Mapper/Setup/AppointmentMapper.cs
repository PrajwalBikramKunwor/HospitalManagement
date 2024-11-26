using System.Collections.Generic;
using System.Linq;
using HospitalManagement.BusinessLayer.DTOs.Setup;
using HospitalManagement.DataAccessLayer.Model;

namespace HospitalManagement.BusinessLayer.Mapper
{
    public class AppointmentMapper
    {
        public static List<AppointmentDTO> GetAllAppointmentDTO(List<Appointment> AppointmentList)
        {

            var AppointmentDTOList = AppointmentList.Select(x => new AppointmentDTO
            {
                AppointmentId = x.AppointmentId,
                Description = x.Description,
                AppointmentDate = x.AppointmentDate,
                DoctorId = x.DoctorId,
                StartTime = x.StartTime,
                IsAllDay = x.IsAllDay,
                EndTime = x.EndTime,
                PatientId = x.PatientId,
                Status = x.Status,
                UserCreatedId = x.UserCreatedId,
                Title = x.Title,
            }).ToList();

            return AppointmentDTOList;
        }

        public static Appointment GetAppointmentDAO(AppointmentDTO x)
        {

            return new Appointment()
            {
                AppointmentId = x.AppointmentId,
                Description = x.Description,
                AppointmentDate = x.AppointmentDate,
                DoctorId = x.DoctorId,
                StartTime = x.StartTime,
                IsAllDay = x.IsAllDay,
                EndTime = x.EndTime,
                PatientId = x.PatientId,
                Status = x.Status,
                UserCreatedId = x.UserCreatedId,
                Title = x.Title,
                
            };
        }

        public static AppointmentDTO GetAppointmentDTO(Appointment x)
        {

            return new AppointmentDTO()
            {
                AppointmentId = x.AppointmentId,
                Description = x.Description,
                AppointmentDate = x.AppointmentDate,
                DoctorId = x.DoctorId,
                StartTime = x.StartTime,
                IsAllDay = x.IsAllDay,
                EndTime = x.EndTime,
                PatientId = x.PatientId,
                Status = x.Status,
                UserCreatedId = x.UserCreatedId,
                Title = x.Title,
            };
        }
    }
}
