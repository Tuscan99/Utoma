using System.Linq;

namespace Utoma.Models
{
    public class EFNewsRepository : INewsRepository
    {
        private readonly CatalogDbContext context;
        public EFNewsRepository(CatalogDbContext _context)
        {
            context = _context;
        }

        public IQueryable<News> newsArticles => context.newsArticles;

        public void AddNews(News newsArticle)
        {
            context.newsArticles.Add(newsArticle);
            context.SaveChanges();
        }

        public void UpdateNews(News newsArticle)
        {
            context.newsArticles.Update(newsArticle);
            context.SaveChanges();
        }

        public News DeleteNews(int Id)
        {
            News record = context.newsArticles.FirstOrDefault(s => s.newsId == Id);
            if (record != null)
            {
                context.newsArticles.Remove(record);
                context.SaveChanges();
            }
            return record;
        }
    }
}
