using System;
using System.Collections.Generic;
using System.Linq;
using HospitalManagement.DataAccessLayer.DbAccess;
using HospitalManagement.DataAccessLayer.Model;

namespace HospitalManagement.BusinessLayer.Repository
{
    public class PatientInfoRepository : IDisposable
    {
        private readonly UnitOfWork _unitOfWork;

        public PatientInfoRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<PatientInfo> PatientInfoList()
        {
            try
            {
                var result = _unitOfWork.PatientInfoRepository.GetAll().ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PatientInfo GetPatientInfoById(string PatientInfoName)
        {
            try
            {
                if (PatientInfoName != null)
                {
                    var result = _unitOfWork.PatientInfoRepository.GetBy(x => x.FirstName == PatientInfoName).FirstOrDefault();
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreatePatientInfo(PatientInfo model)
        {
            try
            {

                var result = _unitOfWork.PatientInfoRepository.Add(model).PatientId;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PatientInfo GetPatientInfoByIdd(int MnId)
        {
            try
            {
                if (MnId != 0)
                {
                    var result = _unitOfWork.PatientInfoRepository.FindBy(x => x.PatientId == MnId);
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PatientInfo GetPatientInfoByUserCreatedId(string UserCreatedID)
        {
            try
            {
                if (UserCreatedID != "")
                {
                    var result = _unitOfWork.PatientInfoRepository.FindBy(x => x.UserCreatedId == UserCreatedID);
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePatientInfo(int mnId)
        {
            try
            {
                var menuModel = _unitOfWork.PatientInfoRepository.FindBy(x => x.PatientId == mnId);

                _unitOfWork.PatientInfoRepository.Delete(menuModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdatePatientInfo(PatientInfo model)
        {
            try
            {
                 _unitOfWork.PatientInfoRepository.Update(model);
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
