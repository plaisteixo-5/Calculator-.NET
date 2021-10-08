using System;
using FluentValidator;
using StoreDomain.StoreContext.Commands.CustomerCommands.Inputs;
using StoreDomain.StoreContext.Entities;
using StoreDomain.StoreContext.Repositories;
using StoreDomain.StoreContext.Services;
using StoreDomain.StoreContext.ValueObjects;
using StoreShared.Commands;

namespace StoreDomain.StoreContext.Handlers
{
    public class CustomerHandler :
    Notifiable,
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verifica se o CPF Já existe
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "CPF já cadastrado no banco.");

            // Verifica se o Email já existe
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Email já cadastrado no banco.");

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

            if (Invalid)
                return new CommandResult(
                    false,
                    "Something went wrong!",
                    Notifications
                );

            // Persiste o cliente
            _repository.Save(customer);

            // Enviar um E-mail de boas vindas
            _emailService.Send(email.Address, "Jorge", "Tô com sono", "Queria dormir mané!");
            // Retornar o resultado para a tela
            return new CommandResult(
                true,
                "Welcome to balta store",
                new
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email
                }
            );
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}