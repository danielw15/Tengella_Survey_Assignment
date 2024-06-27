using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Tengella.Survey.WebApp.ServiceInterface;
using Tengella.Survey.WebApp.Settings;

namespace Tengella.Survey.WebApp.Service
{
    public class MailSender : IMailSender
    {
        public MailSettings _emailSettings {  get; }
        public MailSender(IOptions<MailSettings> emailSettings) 
        {
            _emailSettings = emailSettings.Value;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            Execute(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string email, string subject, string message)
        {
            try
            {
                string toEmail;
                if (string.IsNullOrEmpty(email)){
                    toEmail = _emailSettings.ToEmail;
                }
               else
                {
                    toEmail = email;
                }
                

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.FromAddress, _emailSettings.FromName)
                };

                mail.To.Add(new MailAddress(toEmail));

                if (!string.IsNullOrEmpty(_emailSettings.CcEmail))
                    mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                if (!string.IsNullOrEmpty(_emailSettings.BccEmail))
                    mail.Bcc.Add(new MailAddress(_emailSettings.BccEmail));

                

                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;

                using (SmtpClient smtp = new SmtpClient(_emailSettings.ServerAddress, _emailSettings.ServerPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);
                    smtp.EnableSsl = _emailSettings.ServerUseSsl;

                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

