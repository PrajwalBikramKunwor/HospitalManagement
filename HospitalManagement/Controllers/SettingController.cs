﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.BusinessLayer.Interface;

namespace HospitalManagement.Web.Controllers
{
    public class SettingController : BaseController
    {
        private readonly ISettingService _SettingService;

        public SettingController(ISettingService SettingService)
        {
            _SettingService = SettingService;
        }
        
        [Authorize(Roles = "SUPER")]
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var result = _SettingService.GetAllSetting();
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public JsonResult UpdateSetting(SettingDTO model)
        {
            try
            {
                _SettingService.UpdateSetting(model);
                return Json("success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}