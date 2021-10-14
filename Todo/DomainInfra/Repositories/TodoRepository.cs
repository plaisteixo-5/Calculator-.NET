using System;
using Domain.Entities;
using Domain.Repositories;

namespace DomainInfra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid id, string user)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todo)
        {
            throw new NotImplementedException();
        }
    }
}