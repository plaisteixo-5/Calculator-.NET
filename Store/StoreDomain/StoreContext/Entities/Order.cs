using System;
using System.Collections.Generic;
using StoreDomain.StoreContext.Enums;
using System.Linq;
using FluentValidator;

namespace StoreDomain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        public Customer Customer { get; private set; }

        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            // Valida o item
            // Adiciona o pedido
            if (quantity > product.QuantityOnHand)
            {
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens no estoque.");
            }

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }
        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }
        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_items.Count == 0)
                AddNotification("Order", "Este pedido não possui itens.");
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;

        }

        public void Ship()
        {
            var delivires = new List<Delivery>();
            var count = 1;

            // Quebra as entregas
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 0;
                    delivires.Add(new Delivery(new DateTime().AddDays(5)));
                }
                else
                {
                    count++;

                }
            }
            // Envia as entregas
            delivires.ForEach(x => x.Shipp());

            // Adiciona as entregas ao pedido
            delivires.ForEach(x => _deliveries.Add(x));

            var delivery = new Delivery(DateTime.Now.AddDays(5));
            _deliveries.Add(delivery);
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}
