using HospitalManagement.BusinessLayer.BusinessService;
using HospitalManagement.BusinessLayer.Interface;
using HospitalManagement.BusinessLayer.Interfaces.Setup;
using HospitalManagement.BusinessLayer.Repository;
using HospitalManagement.BusinessLayer.Services.Setup;
using HospitalManagement.DataAccessLayer.DbAccess;

namespace HospitalManagement.BusinessLayer.Helper;
public class ConfigService
{
    public static void ConfigureIService(IServiceCollection services)
    {
        // Register other repositories and services
        services.AddScoped<UnitOfWork>();
        services.AddScoped<StockRepository>();
        services.AddScoped<MenuHeaderRepository>();
        services.AddScoped<CompanyRepository>();
        services.AddScoped<BannerRepository>();
        services.AddScoped<ColorImagesRepository>();
        services.AddScoped<PatientInfoRepository>();
        services.AddScoped<AppointmentRepository>();

        // Register SettingRepository
        services.AddScoped<SettingRepository>(); // Add this line

        // Register services
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<IMenuHeaderService, MenuHeaderService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IBannerService, BannerService>();
        services.AddScoped<IColorImagesService, ColorImagesService>();
        services.AddScoped<IPatientInfoService, PatientInfoService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddTransient<EmailService>();

        // Register MVCHelper
        services.AddScoped<MVCHelper>();
    }


}
