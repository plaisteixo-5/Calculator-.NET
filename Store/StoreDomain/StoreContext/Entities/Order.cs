using System;
using System.Collections.Generic;
using StoreDomain.StoreContext.Enums;
using FluentValidation;
using System.Linq;

namespace StoreDomain.StoreContext.Entities
{
    public class Order
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

        public void AddItem(OrderItem item)
        {
            // Valida o item
            // Adiciona o pedido
            _items.Add(item);
        }
        public void AddDeliverry(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }
        public void Place()
        {
            if (_items.Count == 0)
                Console.WriteLine("Order", "Este pedido não possui itens.");
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;

        }

        public void Shipp()
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
