namespace backend_shopapp.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmail(string toEmail, string subject, string body);
    }
}
