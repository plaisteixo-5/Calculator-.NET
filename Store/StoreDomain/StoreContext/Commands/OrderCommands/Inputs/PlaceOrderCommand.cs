
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using FluentValidator.Validation;
using StoreShared.Commands;

namespace StoreDomain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool IsValid()
        {

            AddNotifications(new ValidationContract()
                .Requires()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente não encontrado.")
                .IsGreaterThan(OrderItems.Count(), 0, "Document", "Nenhum item do pedido foi encontrado."));

            return Valid;
        }
    }
}
