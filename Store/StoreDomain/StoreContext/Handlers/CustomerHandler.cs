using System;
using FluentValidator;
using StoreDomain.StoreContext.Commands.CustomerCommands.Inputs;
using StoreDomain.StoreContext.Entities;
using StoreDomain.StoreContext.ValueObjects;
using StoreShared.Commands;

namespace StoreDomain.StoreContext.Handlers
{
    public class CustomerHandler :
    Notifiable,
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verifica se o CPF Já existe

            // Verifica se o Email já existe

            // Cria os VO's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Cria a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Valida as entidades e VO's
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            // Persiste o cliente

            // Enviar um E-mail de boas vindas

            // Retornar o resultado para a tela
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}