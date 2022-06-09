using System.Linq;

namespace Utoma.Models
{
    public class EFSubscriptionRepository : ISubscriptionRepository
    {
        private readonly CatalogDbContext context;

        public EFSubscriptionRepository(CatalogDbContext _context)
        {
            context = _context;
        }

        public IQueryable<Subscription> subscriptions => context.subscriptions;

        public void AddSubscription(Subscription subscription)
        {
            context.subscriptions.Add(subscription);
            context.SaveChanges();
        }

        public void UpdateSubscription(Subscription subscription)
        {
            context.subscriptions.Update(subscription);
            context.SaveChanges();
        }

        public Subscription DeleteSubscription(int subscriptionId)
        {
            Subscription record = context.subscriptions.FirstOrDefault(s => s.Id == subscriptionId);
            if (record != null)
            {
                context.subscriptions.Remove(record);
                context.SaveChanges();
            }
            return record;
        }
    }
}
