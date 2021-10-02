using FluentValidator;
using FluentValidator.Validation;
using StoreShared.Commands;

namespace StoreDomain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public bool IsValid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracter.")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres.")
                .IsEmail(Email, "Email", "O E-mail é inválido.")
                .HasLen(Document, 11, "Document", "CPF Inválido"));

            return Valid;
        }
    }
}
