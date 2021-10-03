using StoreDomain.StoreContext.Entities;
using StoreDomain.StoreContext.Repositories;

namespace StoreTests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string document)
        {
            return false;
        }

        public void Save(Customer customer) { }
    }
}