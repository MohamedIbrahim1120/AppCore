using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace TestCoreApp.Models
{
    public class clsEmailConfirm : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fmail = "mo7m3d1235@gmail.com";
            var fpassword = "";

            var themsg = new MailMessage();
            themsg.From = new MailAddress(fmail);
            themsg.Subject = subject;
            themsg.To.Add(email);
            themsg.Body = $"<html><body>{htmlMessage}</body></html>";
            themsg.IsBodyHtml = true;


            var smtpclint = new SmtpClient("smtp-mail.outlook.com")
            {
                EnableSsl = true ,
                Credentials = new NetworkCredential(fmail,fpassword),
                Port = 587

            };
            smtpclint.Send(themsg);
        }
    }
}
