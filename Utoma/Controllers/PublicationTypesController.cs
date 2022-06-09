using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Utoma.Models;
using Microsoft.AspNetCore.Authorization;

namespace Utoma.Controllers
{
    [Authorize]
    public class PublicationTypesController : Controller
    {
        private CatalogDbContext context;
        private IPublicationTypeRepository repository;
        public PublicationTypesController(CatalogDbContext _context, IPublicationTypeRepository _repository)
        {
            context = _context;
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View(repository.publicationTypes);
        }

        public IActionResult EditType(int id)
        {
            return View(context.publicationTypes.FirstOrDefault(c => c.PublicationTypeId == id));
        }

        [HttpPost]
        public IActionResult EditType(PublicationType type)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateType(type);
                return RedirectToAction("Index");
            }
            return View(type);

        }

        public IActionResult AddType()
        {
            return View("EditType", new PublicationType());
        }

        [HttpPost]
        public IActionResult AddType(PublicationType type)
        {
            repository.AddType(type);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteType(PublicationType type)
        {
            PublicationType archName = context.publicationTypes.FirstOrDefault(t => t.PublicationTypeId == type.PublicationTypeId);
            if (archName != null)
            {
                archName.PublicationTypeName = string.Concat(type.PublicationTypeName, "_(archive)");
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
