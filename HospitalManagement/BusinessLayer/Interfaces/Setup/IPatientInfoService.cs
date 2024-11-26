using System.Collections.Generic;
using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.BusinessLayer.DTOs;
using HospitalManagement.Models;

namespace HospitalManagement.BusinessLayer.Interface
{
    public interface IPatientInfoService
    {
        List<PatientInfoDTO> GetAllPatientInfo();
        string GetValueByName(string PatientInfoName);
        PatientInfoDTO GetPatientInfoById(string PatientInfoName);
        bool DeletePatientInfo(int mnId);
        PatientInfoDTO GetPatientInfoByIdd(int MnId);
        PatientInfoDTO GetPatientInfoByCreatedId(string UserCreatedId);
        int CreatePatientInfo(PatientInfoDTO PatientInfoUI);
    }
}