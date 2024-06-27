using Microsoft.AspNetCore.Mvc;
using Tengella.Survey.WebApp.ServiceInterface;

namespace Tengella.Survey.WebApp.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailSender _mailSender;

        public MailController(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public async Task TestAction()
        {
            await _mailSender.SendEmailAsync("danielwallen1233@gmail.com", "This is a test", $"Enter email body here");
        }

        public async Task SendEmail(string email, string subject, string message)
        {
            await _mailSender.SendEmailAsync(email, subject, message);
        }




    }
}
