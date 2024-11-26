using System.Collections.Generic;
using HospitalManagement.BusinessLayer.DTOs.Setup;
using HospitalManagement.Models;

namespace HospitalManagement.BusinessLayer.Interface
{
    public interface IAppointmentService
    {
        List<AppointmentDTO> GetAllAppointment();
        string GetValueByName(string AppointmentName);
        AppointmentDTO GetAppointmentById(string AppointmentName);
        bool DeleteAppointment(int mnId);
        AppointmentDTO GetAppointmentByIdd(int MnId);
        AppointmentDTO GetAppointmentByCreatedId(string UserCreatedId);
        AppointmentDTO GetAppointmentByAppointmentDate(DateTime AppointmentDate);
        List<AppointmentDTO> GetAllAppointmentListByAppointmentDate(DateTime AppointmentDate);
        int CreateAppointment(AppointmentDTO AppointmentUI);
        int CreateAppointmentInfo(AppointmentDTO AppointmentDTO);
    }
}