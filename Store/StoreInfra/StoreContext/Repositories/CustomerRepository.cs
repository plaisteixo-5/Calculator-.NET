using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using StoreDomain.StoreContext.Entities;
using StoreDomain.StoreContext.Queries;
using StoreDomain.StoreContext.Repositories;
using StoreInfra.StoreContext.DataContexts;

namespace StoreInfra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }
        public bool CheckDocument(string document)
        {
            return
                _context
                .Connection
                .Query<bool>(
                    "spCheckDocument",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure
                )
                .FirstOrDefault();

            // return
            //     _context
            //     .Connection
            //     .Query<bool>(
            //         "select * from customer where document=@Document",
            //         new { Document = document },
            //     )
            //     .FirstOrDefault();

        }

        public bool CheckEmail(string email)
        {
            return
                _context
                .Connection
                .Query<bool>(
                    "spCheckEmail",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure
                )
                .FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            // Nessa parte aqui, poderiamos criar uma stored procedure
            return
                _context
                .Connection
                .Query<ListCustomerQueryResult>(
                    @"SELECT
                        [Id],
                        CONCAT([FirstName], ' ', [LastName]) AS [Name],
                        [Document],
                        [Email]
                    FROM
                        [Customer]"
                );
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            return
                _context
                .Connection
                .Query<GetCustomerQueryResult>(
                    @"SELECT
                        [Id],
                        CONCAT([FirstName], ' ', [LastName]) AS [Name],,
                        [Document],
                        [Email]
                    FROM
                        [Customer]
                    WHERE
                        [Id] = @Id",
                    new { Id = id }
                ).FirstOrDefault();
        }

        public GetCustomerQueryResult Get(string document)
        {
            return
                _context
                .Connection
                .Query<GetCustomerQueryResult>(
                    @"SELECT
                        [Id],
                        CONCAT([FirstName], ' ', [LastName]) AS [Name],,
                        [Document],
                        [Email]
                    FROM
                        [Customer]
                    WHERE
                        [Document] = @Document",
                    new { Document = document }
                ).FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return
                _context
                .Connection
                .Query<CustomerOrdersCountResult>(
                    "spGetCustomerOrdersCount",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure
                )
                .FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return
                _context
                .Connection
                .Query<ListCustomerOrderQueryResult>(
                    @"SELECT
                        [Customer].[Id],
                        CONCAT([Customer].[FirstName], ' ', [Customer].[LastName]) AS [Name],
                        [Customer].[Document],
                        [Customer].[Email],
                        [Order].[Number],
                        [Order].[Total]
                    FROM
                        [Customer]
                    INNER JOIN [Order] ON [Order].[CustomerId] = @Id",
                    new { Id = id }
                ).ToList();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
            new
            {
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                CheckDocument = customer.Document.Number,
                Email = customer.Email.Address,
                Phone = customer.Phone
            }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                new
                {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public UpdateCustomerQureyResult UpdateCustomer(Customer customer)
        {
            return
                _context
                .Connection
                .Query<UpdateCustomerQureyResult>(
                    @"UPDATE 
                        [Customer]
                    SET
                        [Name] = @Name,
                        [Document] = @Document,
                        [Email] = @Email,
                        [Phone] = @Phone",
                    new
                    {
                        Name = customer.Name,
                        Document = customer.Document,
                        Email = customer.Email,
                        Phone = customer.Phone
                    }
                )
                .FirstOrDefault();
        }
    }
}