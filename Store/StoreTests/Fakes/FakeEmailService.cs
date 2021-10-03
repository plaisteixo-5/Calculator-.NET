using StoreDomain.StoreContext.Services;

namespace StoreTests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body) { }
    }
}