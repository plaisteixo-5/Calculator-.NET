using Domain.Commands;
using Domain.Handlers;
using DomainShared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DomainAPI.Controllers
{

    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler
        )
        {
            command.User = "Felipe Fon";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}