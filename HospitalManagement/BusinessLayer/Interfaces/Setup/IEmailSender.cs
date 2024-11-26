namespace HospitalManagement.BusinessLayer.Interfaces.Setup
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
