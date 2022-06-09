using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Utoma.Models;
using Microsoft.AspNetCore.Authorization;

namespace Utoma.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private CatalogDbContext _catalogDbContext;
        private ICategoryRepository _categoryRepository;
        public CategoriesController(CatalogDbContext context, ICategoryRepository repository)
        {
            _catalogDbContext = context;
            _categoryRepository = repository;
        }
        public IActionResult Index()
        {
            return View(_categoryRepository.categories);
        }

        public IActionResult EditCategory(int id)
        {
            return View(_catalogDbContext.categories.FirstOrDefault(c => c.CategoryId == id));
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);

        }

        public IActionResult AddCategory()
        {
            return View("EditCategory", new Category());
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            Category archName = _catalogDbContext.categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (archName != null)
            {
                archName.CategoryName = string.Concat(category.CategoryName, "_(archive)");
                _catalogDbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
