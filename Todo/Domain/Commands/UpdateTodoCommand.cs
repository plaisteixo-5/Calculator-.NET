using System;
using DomainShared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand() { }
        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = Guid.NewGuid();
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new ValidationContract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "O título deve ter mais de 3 caracteres!")
                .HasMinLen(User, 6, "User", "Usuário inválido")
            );
        }
    }
}