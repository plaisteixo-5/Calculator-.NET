using System;
using StoreDomain.StoreContext.Enums;
using StoreShared.Entities;

namespace StoreDomain.StoreContext.Entities
{
    public class Delivery : Entity
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
            Status = EDeliveryStatus.Canceled;
        }
    }
}