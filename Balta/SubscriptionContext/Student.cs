using System.Collections.Generic;
using System.Linq;
using Balta.ContentContext;
using Balta.NotificationContext;

namespace Balta.SubscriptionContext
{
    public class Student : Base
    {
        public Student()
        {
            Subscriptions = new List<Subscripton>();
        }
        public User User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Subscripton> Subscriptions { get; set; }
        public bool IsPremium => Subscriptions.Any(x => !x.IsInactive);

        public void CreateSubscription(Subscripton subscripton)
        {
            if (IsPremium)
            {
                AddNotification(new Notification("Premium", "O aluno já tem uma assinatura ativa"));
                return;
            }
            Subscriptions.Add(subscripton);
        }
    }
}