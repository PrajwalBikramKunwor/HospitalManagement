namespace HospitalManagement.BusinessLayer.Services.Setup;

using HospitalManagement.BusinessLayer.Interfaces.Setup;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

public class EmailSender : Interfaces.Setup.IEmailSender
{
    //public Task SendEmailAsync(string email, string subject, string message)
    //{
    //    var mail = "TahirHussain2213@gmail.com";
    //    var pass = "Passwordplz10";
    //    var client = new SmtpClient("smtp.office365.com", 587)
    //    {
    //        EnableSsl = true,
    //        //UseDefaultCredentials = false,
    //        Credentials = new NetworkCredential(mail,pass)
    //    };

    //    return client.SendMailAsync(
    //        new MailMessage(from: mail,
    //                        to: email,
    //                        subject,
    //                        message
    //                        ));
    //}
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var mail = "TahirHussain32145@gmail.com";
        var pass = "Passwordplz10";
        try
        {
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mail, pass)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(mail),
                Subject = subject,
                Body = message,
                IsBodyHtml = true // Set true if HTML content
            };
            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);
        }
        catch (Exception ex)
        {
            // Log the exception (e.g., to a file or monitoring service)
            Console.WriteLine($"Email sending failed: {ex.Message}");
            throw; // Re-throw if you want the calling function to handle it
        }
    }
}