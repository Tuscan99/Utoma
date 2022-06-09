using System.Linq;

namespace Utoma.Models
{
    public class EFPublisherRepository : IPublisherRepository
    {
        private readonly CatalogDbContext context;

        public EFPublisherRepository(CatalogDbContext _context)
        {
            context = _context;
        }
        public IQueryable<Publisher> publishers => context.publishers;

        public void AddPublisher(Publisher publisher)
        {
            context.publishers.Add(publisher);
            context.SaveChanges();
        }

        public void UpdatePublisher(Publisher publisher)
        {
            context.publishers.Update(publisher);
            context.SaveChanges();
        }
    }
}
