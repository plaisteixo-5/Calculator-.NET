using System;
using FluentValidator;
using StoreDomain.StoreContext.Enums;
using StoreShared.Commands;

namespace StoreDomain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }

        bool ICommand.IsValid()
        {
            return Valid;
        }
    }

}
