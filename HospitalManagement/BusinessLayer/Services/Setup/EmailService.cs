using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MailKit.Security;

namespace HospitalManagement.BusinessLayer.Services.Setup
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            // Sender details
            emailMessage.From.Add(new MailboxAddress(
                _configuration["SmtpSettings:SenderName"],
                _configuration["SmtpSettings:SenderEmail"]
            ));

            // Receiver details
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = subject;

            // Email body
            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            try
            {
                // Connect to the SMTP server with SSL
                await client.ConnectAsync(
                    _configuration["SmtpSettings:Server"],
                    int.Parse(_configuration["SmtpSettings:Port"]),
                    SecureSocketOptions.SslOnConnect // Use SSL for port 465
                );

                // Authenticate with your Gmail App password
                await client.AuthenticateAsync(
                    _configuration["SmtpSettings:Username"],
                    _configuration["SmtpSettings:Password"]
                );

                // Send email
                await client.SendAsync(emailMessage);
                return true;
            }
            catch (SmtpProtocolException ex)
            {
                // Handle SMTP protocol error
                Console.WriteLine($"SMTP protocol error: {ex.Message}");
                // You may want to add logging or retry logic here
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Disconnect from the SMTP server and dispose the client
                await client.DisconnectAsync(true);
                client.Dispose();
            }

            return false;
        }
    }
}
