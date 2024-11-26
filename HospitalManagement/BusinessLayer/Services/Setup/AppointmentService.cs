using Mapster;
using System;
using HospitalManagement.BusinessLayer.DTOs.Setup;
using HospitalManagement.BusinessLayer.Interface;
using HospitalManagement.BusinessLayer.Mapper;
using HospitalManagement.BusinessLayer.Repository;
using HospitalManagement.DataAccessLayer.DbAccess;
using Microsoft.Data.SqlClient;
using System.Data;
using HospitalManagement.Models;
using HospitalManagement.BusinessLayer.DTOs;

namespace HospitalManagement.BusinessLayer.BusinessService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AppointmentRepository _AppointmentRepository;

        public AppointmentService(UnitOfWork unitOfWork, AppointmentRepository AppointmentRepository)
        {
            _unitOfWork = unitOfWork;
            _AppointmentRepository = AppointmentRepository;
        }

        public List<AppointmentDTO> GetAllAppointment()
        {
            try
            {

                var AppointmentDAOList = _AppointmentRepository.AppointmentList();

                var AppointmentDTOList = AppointmentMapper.GetAllAppointmentDTO(AppointmentDAOList);
                return AppointmentDTOList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public AppointmentDTO GetAppointmentByIdd(int MnId)
        {
            try
            {
                var Appointment = _AppointmentRepository.GetAppointmentByIdd(MnId);
                if (Appointment == null)
                {
                    return null;
                }
                if (MnId > 0)
                {
                    return AppointmentMapper.GetAppointmentDTO(Appointment);
                }
                else
                {
                    return new AppointmentDTO();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AppointmentDTO GetAppointmentByCreatedId(string UserCreatedId)
        {
            try
            {
                var Appointment = _AppointmentRepository.GetAppointmentByUserCreatedId(UserCreatedId);
                if (Appointment == null)
                {
                    return null;
                }
                if (Appointment != null)
                {
                    return AppointmentMapper.GetAppointmentDTO(Appointment);
                }
                else
                {
                    return new AppointmentDTO();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AppointmentDTO GetAppointmentByAppointmentDate(DateTime AppointmentDate)
        {
            try
            {
                var Appointment = _AppointmentRepository.GetAppointmentByAppointmentDate(AppointmentDate);
                if (Appointment == null)
                {
                    return null;
                }
                if (Appointment != null)
                {
                    return AppointmentMapper.GetAppointmentDTO(Appointment);
                }
                else
                {
                    return new AppointmentDTO();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AppointmentDTO> GetAllAppointmentListByAppointmentDate(DateTime AppointmentDate)
        {
            try
            {

                var AppointmentDAOList = _AppointmentRepository.AppointmentListByAppointmentDate(AppointmentDate);

                var AppointmentDTOList = AppointmentMapper.GetAllAppointmentDTO(AppointmentDAOList);
                return AppointmentDTOList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public AppointmentDTO GetAppointmentById(string AppointmentName)
        {
            try
            {

                var AppointmentDAO = _AppointmentRepository.GetAppointmentById(AppointmentName);
                var AppointmentDTOMOdel = AppointmentMapper.GetAppointmentDTO(AppointmentDAO);

                return AppointmentDTOMOdel;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int CreateAppointment(AppointmentDTO AppointmentUI)
        {
            try
            {

                var AppointmentModel = AppointmentMapper.GetAppointmentDAO(AppointmentUI);
                if (AppointmentModel.AppointmentId > 0)
                {
                    var stockDAO = _AppointmentRepository.GetAppointmentByIdd(AppointmentUI.AppointmentId);
                    AppointmentModel.AppointmentId = stockDAO.AppointmentId;

                    AppointmentModel = AppointmentModel.Adapt(stockDAO);
                    var result = _AppointmentRepository.UpdateAppointment(AppointmentModel);
                    return AppointmentUI.AppointmentId;
                }
                else
                {
                    return _AppointmentRepository.CreateAppointment(AppointmentModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateAppointmentInfo(AppointmentDTO AppointmentDTO)
        {
            try
            {

                var AppointmentInfoModel = AppointmentMapper.GetAppointmentDAO(AppointmentDTO);
                if (AppointmentInfoModel.AppointmentId > 0)
                {
                    var appointmentDAO = _AppointmentRepository.GetAppointmentByIdd(AppointmentDTO.AppointmentId);
                    AppointmentInfoModel.PatientId = appointmentDAO.PatientId;

                    AppointmentInfoModel = AppointmentInfoModel.Adapt(appointmentDAO);
                    var result = _AppointmentRepository.UpdateAppointment(AppointmentInfoModel);
                    return AppointmentInfoModel.PatientId;
                }
                else
                {
                    return _AppointmentRepository.CreateAppointment(AppointmentInfoModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GetValueByName(string AppointmentName)
        {
            try
            {

                return _AppointmentRepository.GetAppointmentById(AppointmentName).Description;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public bool DeleteAppointment(int mnId)
        {
            try
            {


                var result = _AppointmentRepository.DeleteAppointment(mnId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  

    }

}