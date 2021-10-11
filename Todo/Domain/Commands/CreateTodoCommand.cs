using System;
using DomainShared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Domain.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public CreateTodoCommand() { }
        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

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