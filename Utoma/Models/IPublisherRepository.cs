using System.Linq;

namespace Utoma.Models
{
    public interface IPublisherRepository
    {
        IQueryable<Publisher> publishers { get; }
        public void AddPublisher(Publisher publisher);
        public void UpdatePublisher(Publisher publisher);
    }
}

