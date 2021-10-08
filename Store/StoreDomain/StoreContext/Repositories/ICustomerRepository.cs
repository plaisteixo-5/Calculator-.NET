using System;
using System.Collections.Generic;
using StoreDomain.StoreContext.Entities;
using StoreDomain.StoreContext.Queries;

namespace StoreDomain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string document);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(string document);
        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id);
        UpdateCustomerQureyResult UpdateCustomer(Customer customer);
    }
}