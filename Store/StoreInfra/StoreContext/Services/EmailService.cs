using StoreDomain.StoreContext.Services;

namespace StoreInfra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
        }
    }
}