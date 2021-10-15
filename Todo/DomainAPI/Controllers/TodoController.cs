using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using DomainShared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DomainAPI.Controllers
{

    // CHAMA O REPOSITORY QUANDO FOR LEITURA E OS HANDLERS QUANDO FOR ESCRITA
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            return repository.GetAll(user);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            return repository.GetAllDone(user);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone(
            [FromServices] ITodoRepository repository
        )
        {

            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            return repository.GetAllUndone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date,
                true
            );
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date,
                false
            );
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date.AddDays(1),
                true
            );
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date.AddDays(1),
                false
            );
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            command.User = user;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            command.User = user;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            command.User = user;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user id")?.Value;
            command.User = user;
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}