using System;

namespace StoreDomain.StoreContext.Commands.OrderCommands.Inputs
{
    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}