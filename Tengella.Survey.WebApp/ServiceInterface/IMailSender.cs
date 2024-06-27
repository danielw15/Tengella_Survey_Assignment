namespace Tengella.Survey.WebApp.ServiceInterface
{
    public interface IMailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
