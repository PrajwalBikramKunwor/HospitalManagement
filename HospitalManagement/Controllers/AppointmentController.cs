using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalManagement.BusinessLayer.DTOs;
using HospitalManagement.BusinessLayer.Interface;
using HospitalManagement.BusinessLayer.BusinessService;
using HospitalManagement.Models;
using HospitalManagement.BusinessLayer.DTOs.Setup;
using Microsoft.AspNetCore.Identity;
using HospitalManagement.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using HospitalManagement.BusinessLayer.Helper;
using System.Globalization;
using HospitalManagement.BusinessLayer.Interfaces.Setup;
using HospitalManagement.BusinessLayer.Services.Setup;

namespace HospitalManagement.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _AppointmentService;
        private readonly IPatientInfoService _patientInfoService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MVCHelper _MVCHelper;
        private readonly IEmailSender emailSender;
        private readonly EmailService _emailService;

        public AppointmentController(IAppointmentService AppointmentService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, MVCHelper mVCHelper, IEmailSender emailSender, IPatientInfoService patientInfoService, EmailService emailService)
        {
            _AppointmentService = AppointmentService;
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationDbContext = context;
            _MVCHelper = mVCHelper;
            this.emailSender = emailSender;
            _patientInfoService = patientInfoService;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                AppointmentDTO Appointment = new();
                var CreatedId = HttpContext.Session.GetString("UserId");
                var patientid = _AppointmentService.GetAppointmentByCreatedId(CreatedId);
                var result = _AppointmentService.GetAllAppointment();
                foreach (var item in result)
                {
                    item.AppointmentDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                }
                Appointment.AppointmentDTOs = result;
                return View(Appointment);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpGet]
        public IActionResult Create(int mnId)
        {
            AppointmentDTO model = new AppointmentDTO();

            if (mnId > 0)
            {
                model = _AppointmentService.GetAppointmentByIdd(mnId);
            }
            else
            {

            }
            List<SelectListItem> returnListItems = new List<SelectListItem>();
            var doctorroles = _roleManager.Roles.Where(x => x.Name == "Doctor").ToList();

            ViewBag.DoctorList = _MVCHelper.BindDropdownList("ROLESLIST", true);
            ViewBag.PatientList = _MVCHelper.BindDropdownList("PATIENTLIST", true);


            //var doctordetail = doctorrole[0];
            //var DoctorList = _userManager.Users.ToList();

            return View("Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(AppointmentDTO model)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var appointmentDetail = _AppointmentService.GetAllAppointmentListByAppointmentDate(model.AppointmentDate);
                    var patientDetail = _patientInfoService.GetPatientInfoByIdd(model.PatientId);
                    var email = "";
                    if (patientDetail != null)
                    {
                        email = patientDetail.Email;
                    }
                    if (appointmentDetail.Count > 0)
                    {
                        foreach (var comp in appointmentDetail)
                        {
                            //if (model.EndTime < comp.EndTime && comp.StartTime < model.StartTime && model.DoctorId == model.DoctorId && comp.Status == "Scheduled" && comp.IsAllDay == false)
                            //{
                            //    return Json("AppointmentFailed");
                            //}
                            if (model.StartTime == comp.StartTime && model.EndTime ==  model.EndTime && model.DoctorId == model.DoctorId && comp.Status == "Scheduled" && comp.IsAllDay == false)
                            {
                                return Json("AppointmentFailed");
                            }
                        }
                    }

                    var CreatedId = HttpContext.Session.GetString("UserId");
                    var CreatedUsername = HttpContext.Session.GetString("Username");
                    if (CreatedId != null)
                    {
                        model.UserCreatedId = CreatedId;
                    }
                    //int StId = _AppointmentService.CreateAppointment(model);
                    int StId = _AppointmentService.CreateAppointmentInfo(model);
                    if (StId != 0)
                    {
                        var message = $"Appointment has been book of Patient {patientDetail.FirstName} {patientDetail.LastName} at {DBNullHandler.FormatDateTime(model.AppointmentDate)} between {model.StartTime} and {model.EndTime}";
                        var msg = _emailService.SendEmailAsync(email, "Patient AppointmentSchedule", message);
                    }
                    return Json("success");
                }


                return Json("Failed");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public bool SendEmal(string email, string subject, string message)
        {
            emailSender.SendEmailAsync(email, subject, message);
            return true;
        }



        public IActionResult Delete(int mnId)
        {
            try
            {
                var data = _AppointmentService.DeleteAppointment(mnId);
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