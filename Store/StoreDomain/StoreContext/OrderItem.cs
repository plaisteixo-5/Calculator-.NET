using System;

namespace StoreDomain.StoreContext
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public string Quantity { get; set; }
        public double Price { get; set; }
    }
}
