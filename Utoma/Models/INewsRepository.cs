using System.Linq;

namespace Utoma.Models
{
    public interface INewsRepository
    {
        public IQueryable<News> newsArticles { get; }
        public void AddNews(News newsArticle);
        public void UpdateNews(News newsArticle);
        public News DeleteNews(int newsId);
    }
}

