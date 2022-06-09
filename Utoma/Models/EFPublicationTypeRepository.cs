using System.Linq;

namespace Utoma.Models
{
    public class EFPublicationTypeRepository : IPublicationTypeRepository
    {
        private readonly CatalogDbContext context;
        public EFPublicationTypeRepository(CatalogDbContext _context)
        {
            this.context = _context;
        }

        public IQueryable<PublicationType> publicationTypes => context.publicationTypes;

        public void AddType(PublicationType type)
        {
            context.publicationTypes.Add(type);
            context.SaveChanges();
        }

        public void UpdateType(PublicationType type)
        {
            context.publicationTypes.Update(type);
            context.SaveChanges();
        }
    }
}
