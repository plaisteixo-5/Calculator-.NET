using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StoreDomain.StoreContext.Commands.CustomerCommands.Inputs;
using StoreDomain.StoreContext.Entities;
using StoreDomain.StoreContext.Handlers;
using StoreDomain.StoreContext.Queries;
using StoreDomain.StoreContext.Repositories;
using StoreDomain.StoreContext.ValueObjects;
using StoreShared.Commands;

namespace StoreApi.Controllers
{
    public class CustomerController
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {

            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id:int}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("v2/customers/{document}")]
        public GetCustomerQueryResult GetByDocument(string document)
        {
            return _repository.Get(document);
        }

        [HttpGet]
        [Route("v1/customers/{id:int}")]
        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public object Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            if (_handler.Invalid) return _handler.Notifications;

            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public UpdateCustomerQureyResult Put([FromBody] Customer customer)
        {
            return _repository.UpdateCustomer(customer);
        }

        [HttpPost]
        [Route("v1/customers/{id}")]
        public object Delete([FromBody] Customer customer)
        {
            return new { message = "Customer removed succed!" };
        }
    }
}