using Mapster;
using System;
using System.Collections.Generic;
using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.BusinessLayer.Interface;
using HospitalManagement.BusinessLayer.Mapper;
using HospitalManagement.BusinessLayer.Repository;
using HospitalManagement.BusinessLayer.Helper;
using HospitalManagement.DataAccessLayer.DbAccess;
using Microsoft.Data.SqlClient;
using System.Data;
using HospitalManagement.Models;
using HospitalManagement.BusinessLayer.DTOs;

namespace HospitalManagement.BusinessLayer.BusinessService
{
    public class PatientInfoService : IPatientInfoService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly PatientInfoRepository _PatientInfoRepository;

        public PatientInfoService(UnitOfWork unitOfWork, PatientInfoRepository PatientInfoRepository)
        {
            _unitOfWork = unitOfWork;
            _PatientInfoRepository = PatientInfoRepository;
        }

        public List<PatientInfoDTO> GetAllPatientInfo()
        {
            try
            {

                var PatientInfoDAOList = _PatientInfoRepository.PatientInfoList();

                var PatientInfoDTOList = PatientInfoMapper.GetAllPatientInfoDTO(PatientInfoDAOList);
                return PatientInfoDTOList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public PatientInfoDTO GetPatientInfoByIdd(int MnId)
        {
            try
            {
                var PatientInfo = _PatientInfoRepository.GetPatientInfoByIdd(MnId);
                if (PatientInfo == null)
                {
                    return null;
                }
                if (MnId > 0)
                {
                    return PatientInfoMapper.GetPatientInfoDTO(PatientInfo);
                }
                else
                {
                    return new PatientInfoDTO();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PatientInfoDTO GetPatientInfoByCreatedId(string UserCreatedId)
        {
            try
            {
                var PatientInfo = _PatientInfoRepository.GetPatientInfoByUserCreatedId(UserCreatedId);
                if (PatientInfo == null)
                {
                    return null;
                }
                if (PatientInfo != null)
                {
                    return PatientInfoMapper.GetPatientInfoDTO(PatientInfo);
                }
                else
                {
                    return new PatientInfoDTO();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public PatientInfoDTO GetPatientInfoById(string PatientInfoName)
        {
            try
            {

                var PatientInfoDAO = _PatientInfoRepository.GetPatientInfoById(PatientInfoName);
                var PatientInfoDTOMOdel = PatientInfoMapper.GetPatientInfoDTO(PatientInfoDAO);

                return PatientInfoDTOMOdel;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int CreatePatientInfo(PatientInfoDTO PatientInfoUI)
        {
            try
            {

                var PatientInfoModel = PatientInfoMapper.GetPatientInfoDAO(PatientInfoUI);
                if (PatientInfoModel.PatientId > 0)
                {
                    var stockDAO = _PatientInfoRepository.GetPatientInfoByIdd(PatientInfoUI.PatientId);
                    PatientInfoModel.PatientId = stockDAO.PatientId;

                    PatientInfoModel = PatientInfoModel.Adapt(stockDAO);
                    var result = _PatientInfoRepository.UpdatePatientInfo(PatientInfoModel);
                    return PatientInfoUI.PatientId;
                }
                else
                {
                    return _PatientInfoRepository.CreatePatientInfo(PatientInfoModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GetValueByName(string PatientInfoName)
        {
            try
            {

                return _PatientInfoRepository.GetPatientInfoById(PatientInfoName).FirstName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public bool DeletePatientInfo(int mnId)
        {
            try
            {


                var result = _PatientInfoRepository.DeletePatientInfo(mnId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  

    }

}