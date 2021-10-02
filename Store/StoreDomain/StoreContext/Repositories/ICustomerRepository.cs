using StoreDomain.StoreContext.Entities;

namespace StoreDomain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string document);
        void Save(Customer customer);
    }
}