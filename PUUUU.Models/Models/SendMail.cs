using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PUUUU.Models.Models
{
    public class SendMail : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (MailMessage mailMessage = new MailMessage()) 
            {
                mailMessage.From = new MailAddress("example@email.com");
                mailMessage.Subject = subject;
                mailMessage.Body = email + htmlMessage;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress("example@email.com"));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "";
                NetworkCred.Password = "";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 25;
               await smtp.SendMailAsync(mailMessage);
            }
        }
    }
}
