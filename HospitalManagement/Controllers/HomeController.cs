using HospitalManagement.BusinessLayer.BusinessService;
using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.BusinessLayer.Helper;
using HospitalManagement.BusinessLayer.Interface;
using HospitalManagement.BusinessLayer.Services.Setup;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HospitalManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStockService _stockService;
        private readonly IMenuHeaderService _menuHeaderService;
        private readonly IBannerService _bannerService;
        private readonly IColorImagesService _colorImagesService;
        private readonly ICompanyService _companyService;
        private readonly EmailService _emailService;
        public HomeController(ILogger<HomeController> logger, IStockService stockService, IMenuHeaderService menuHeaderService, IBannerService bannerService, IColorImagesService colorImagesService, ICompanyService companyService, EmailService emailService)
        {
            _logger = logger;
            _stockService = stockService;
            _menuHeaderService = menuHeaderService;
            _bannerService = bannerService;
            _colorImagesService = colorImagesService;
            _companyService = companyService;
            _emailService = emailService;
        }
        public IActionResult Index(string FromDate="",string Todate="")
        {
            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string toEmail, string subject, string message)
        {
            await _emailService.SendEmailAsync(toEmail, subject, message);
            return RedirectToAction("EmailSent"); // Redirect to a confirmation page or show a message
        }

        public IActionResult EmailSender()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
