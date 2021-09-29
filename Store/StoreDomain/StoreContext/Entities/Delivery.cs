using System;
using StoreDomain.StoreContext.Enums;

namespace StoreDomain.StoreContext.Entities
{
    public class Delivery
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimateDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimateDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Shipp()
        {
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            // if (Status == EDeliveryStatus.Delivered)
            Status = EDeliveryStatus.Canceled;
        }
    }
}