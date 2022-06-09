using System.Linq;

namespace Utoma.Models
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly CatalogDbContext context;
        public EFCategoryRepository(CatalogDbContext _context)
        {
            context = _context;
        }

        public IQueryable<Category> categories => context.categories;

        public void AddCategory(Category category)
        {
            context.categories.Add(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            context.categories.Update(category);
            context.SaveChanges();
        }
    }
}
