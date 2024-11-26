using System.Collections.Generic;
using System.Linq;
using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.BusinessLayer.DTOs;
using HospitalManagement.DataAccessLayer.Model;

namespace HospitalManagement.BusinessLayer.Mapper
{
    public class PatientInfoMapper
    {
        public static List<PatientInfoDTO> GetAllPatientInfoDTO(List<PatientInfo> PatientInfoList)
        {

            var PatientInfoDTOList = PatientInfoList.Select(x => new PatientInfoDTO
            {
                PatientId = x.PatientId,
                FirstName = x.FirstName,
                Address = x.Address,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                Gender = x.Gender,
                LastName = x.LastName,
                MedicalRecords = x.MedicalRecords,
                PhoneNumber = x.PhoneNumber,
                UserCreatedId = x.UserCreatedId,
            }).ToList();

            return PatientInfoDTOList;
        }

        public static PatientInfo GetPatientInfoDAO(PatientInfoDTO x)
        {

            return new PatientInfo()
            {
                PatientId = x.PatientId,
                FirstName = x.FirstName,
                Address = x.Address,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                Gender = x.Gender,
                LastName = x.LastName,
                MedicalRecords = x.MedicalRecords,
                PhoneNumber = x.PhoneNumber,
                UserCreatedId = x.UserCreatedId,

            };
        }

        public static PatientInfoDTO GetPatientInfoDTO(PatientInfo x)
        {

            return new PatientInfoDTO()
            {
                PatientId = x.PatientId,
                FirstName = x.FirstName,
                Address = x.Address,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                Gender = x.Gender,
                LastName = x.LastName,
                MedicalRecords = x.MedicalRecords,
                PhoneNumber = x.PhoneNumber,
                UserCreatedId = x.UserCreatedId,

            };
        }
    }
}
