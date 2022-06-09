using Microsoft.EntityFrameworkCore;

namespace Utoma.Models
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

        public DbSet<Periodical> periodicals { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<PublicationType> publicationTypes { get; set; }
        public DbSet<Publisher> publishers { get; set; }

        public DbSet<Subscription> subscriptions { get; set; }

        public DbSet<News> newsArticles { get; set; }
    }
}
