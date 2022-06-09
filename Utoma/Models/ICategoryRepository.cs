using System.Linq;

namespace Utoma.Models
{
    public interface ICategoryRepository
    {
        IQueryable<Category> categories { get; }
        void AddCategory(Category category);
        void UpdateCategory(Category category);
    }
}
