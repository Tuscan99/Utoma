using System.Collections.Generic;
using System.Linq;

namespace Utoma.Models
{
    public interface IPublicationTypeRepository
    {
        IQueryable<PublicationType> publicationTypes { get; }
        public void AddType(PublicationType type);
        public void UpdateType(PublicationType type);
    }
}
