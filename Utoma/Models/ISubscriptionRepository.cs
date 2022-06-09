using System.Linq;

namespace Utoma.Models
{
    public interface ISubscriptionRepository
    {
        IQueryable<Subscription> subscriptions { get; }
        public void AddSubscription(Subscription subscription);
        public void UpdateSubscription(Subscription subscription);
        public Subscription DeleteSubscription(int Id);
    }
}
