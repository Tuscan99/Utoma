using System.Linq;

namespace Utoma.Models
{
    public class EFPeriodicalRepository : IPeriodicalRepository
    {
        private CatalogDbContext context;

        public EFPeriodicalRepository(CatalogDbContext _context)
        {
            context = _context;
        }

        public IQueryable<Periodical> periodicals => context.periodicals;
        public void SavePeriodical(Periodical periodical)
        {
            if (periodical.Id == 0)
            {
                context.periodicals.Add(periodical);
            }
            else
            {
                Periodical record = context.periodicals.FirstOrDefault(p => p.Id == periodical.Id);
                if (record != null)
                {
                    record.Id = periodical.Id;
                    record.ISSN = periodical.ISSN;
                    record.Name = periodical.Name;
                    record.NumPages = periodical.NumPages;
                    record.TimesInMonth = periodical.TimesInMonth;
                    record.Price = periodical.Price;
                    record.Description = periodical.Description;
                    record.CoverImage = periodical.CoverImage;
                    record.Thumbnail = periodical.Thumbnail;

                    record.CategoryId = periodical.CategoryId;
                    record.PublicationTypeId = periodical.PublicationTypeId;
                    record.PublisherId = periodical.PublisherId;
                }
            }

            context.SaveChanges();
        }

        public Periodical DeletePeriodical(int periodicalId)
        {
            Periodical record = context.periodicals.FirstOrDefault(p => p.Id == periodicalId);
            if (record != null)
            {
                context.periodicals.Remove(record);
                context.SaveChanges();
            }
            return record;
        }

    }
}
