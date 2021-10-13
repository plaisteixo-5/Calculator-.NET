using System;
using DomainShared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Domain.Commands
{
    public class MarkTodoAsUndoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsUndoneCommand() { }
        public MarkTodoAsUndoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new ValidationContract()
                .Requires()
                .HasMinLen(User, 6, "User", "O usuário é inválido!")
            );
        }
    }
}