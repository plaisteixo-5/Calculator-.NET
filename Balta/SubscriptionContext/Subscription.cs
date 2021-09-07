using System;

namespace Balta.SubscriptionContext
{
    public class Subscripton
    {
        public Plan Plan { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsInactive => EndDate <= DateTime.Now;
    }
}