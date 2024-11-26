using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.BusinessLayer.Interface;
using HospitalManagement.BusinessLayer.BusinessService;
using HospitalManagement.Models;
using HospitalManagement.BusinessLayer.DTOs;

namespace HospitalManagement.Web.Controllers
{
    public class PatientInfoController : BaseController
    {
        private readonly IPatientInfoService _PatientInfoService;

        public PatientInfoController(IPatientInfoService PatientInfoService)
        {
            _PatientInfoService = PatientInfoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                PatientInfoDTO patientInfo = new();
                var CreatedId = HttpContext.Session.GetString("UserId");
                var patientid = _PatientInfoService.GetPatientInfoByCreatedId(CreatedId);
                var result = _PatientInfoService.GetAllPatientInfo();
                patientInfo.PatientDTO = result;
                if(patientid != null)
                patientInfo.PatientRetrieveId = patientid.PatientId;
                return View(patientInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpGet]
        public IActionResult Create(int mnId)
        {
            PatientInfoDTO model = new PatientInfoDTO();

            if (mnId > 0)
            {
                model = _PatientInfoService.GetPatientInfoByIdd(mnId);
            }
            else
            {

            }

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult CreatePost(PatientInfoDTO model)
        {
            try
            {


                if (ModelState.IsValid)
                {

                    var CreatedId = HttpContext.Session.GetString("UserId");
                    var CreatedUsername = HttpContext.Session.GetString("Username");
                    if (CreatedId != null)
                    {
                        model.UserCreatedId = CreatedId;
                    }
                    int StId = _PatientInfoService.CreatePatientInfo(model);
                    return Json("success");
                }


                return Json("Failed");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }



        public IActionResult Delete(int mnId)
        {
            try
            {
                var data = _PatientInfoService.DeletePatientInfo(mnId);
                //return this.Ok(data);
                if (data)
                {
                    return Json(new { success = true, message = "Data Deleted Successfully" });
                }
                else // If deletion failed for some reason
                {
                    return Json(new { success = false, message = "Failed to delete the data" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


    }
}