using System;
using System.Collections.Generic;
using System.Linq;
using HospitalManagement.DataAccessLayer.DbAccess;
using HospitalManagement.DataAccessLayer.Model;

namespace HospitalManagement.BusinessLayer.Repository
{
    public class AppointmentRepository : IDisposable
    {
        private readonly UnitOfWork _unitOfWork;

        public AppointmentRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Appointment> AppointmentList()
        {
            try
            {
                var result = _unitOfWork.AppointmentRepository.GetAll().ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Appointment> AppointmentListByAppointmentDate(DateTime AppointmentDate)
        {
            try
            {
                var result = _unitOfWork.AppointmentRepository.GetAll().Where(x=> x.AppointmentDate ==  AppointmentDate).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Appointment GetAppointmentById(string AppointmentName)
        {
            try
            {
                if (AppointmentName != null)
                {
                    var result = _unitOfWork.AppointmentRepository.GetBy(x => x.Title == AppointmentName).FirstOrDefault();
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateAppointment(Appointment model)
        {
            try
            {

                var result = _unitOfWork.AppointmentRepository.Add(model).AppointmentId;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Appointment GetAppointmentByIdd(int MnId)
        {
            try
            {
                if (MnId != 0)
                {
                    var result = _unitOfWork.AppointmentRepository.FindBy(x => x.AppointmentId == MnId);
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Appointment GetAppointmentByUserCreatedId(string UserCreatedID)
        {
            try
            {
                if (UserCreatedID != "")
                {
                    var result = _unitOfWork.AppointmentRepository.FindBy(x => x.UserCreatedId == UserCreatedID);
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Appointment GetAppointmentByAppointmentDate(DateTime AppointmentDate)
        {
            try
            {
                if (AppointmentDate != null)
                {
                    var result = _unitOfWork.AppointmentRepository.FindBy(x => x.AppointmentDate == AppointmentDate);
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteAppointment(int mnId)
        {
            try
            {
                var menuModel = _unitOfWork.AppointmentRepository.FindBy(x => x.AppointmentId  == mnId);

                _unitOfWork.AppointmentRepository.Delete(menuModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateAppointment(Appointment model)
        {
            try
            {
                 _unitOfWork.AppointmentRepository.Update(model);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
