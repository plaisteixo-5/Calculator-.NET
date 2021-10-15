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
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return new GenericCommandResult(
                    false,
                    "O comando passado está errado",
                    command.Notifications
                );

            var todo = new TodoItem(command.Title, command.User, command.Date);

            _repository.Create(todo);

            return new GenericCommandResult(true, "Todo criado com sucesso!", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();

            if (command.Valid)
                return new GenericCommandResult(
                    false,
                    "O comando passado está errado",
                    command.Notifications
                );

            var todo = _repository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            _repository.Update(todo);

            return new GenericCommandResult(true, "Todo criado com sucesso!", todo);

        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();

            if (command.Valid)
                return new GenericCommandResult(
                    false,
                    "O comando passado está errado",
                    command.Notifications
                );

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Todo criado com sucesso!", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();

            if (command.Valid)
                return new GenericCommandResult(
                    false,
                    "O comando passado está errado",
                    command.Notifications
                );

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUndone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Todo criado com sucesso!", todo);
        }
    }
}