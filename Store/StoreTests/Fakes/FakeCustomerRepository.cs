using StoreDomain.StoreContext.Entities;
using StoreDomain.StoreContext.Queries;
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

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer) { }
    }
}