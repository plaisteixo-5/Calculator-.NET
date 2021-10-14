using Domain.Commands;
using Domain.Entities;
using Domain.Repositories;
using DomainShared.Commands;
using DomainShared.Handlers;
using FluentValidator;

namespace Domain.Handlers
{
    public class TodoHandler :
    Notifiable,
    IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Valid)
                return new GenericCommandResult(
                    false,
                    "O comando passado está errado",
                    command.Notifications
                );

            var todo = new TodoItem(command.Title, command.User, command.Date);

            _repository.Create(todo);

            return new GenericCommandResult(true, "Todo criado com sucesso!", todo);
        }
    }
}