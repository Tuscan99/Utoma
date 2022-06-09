using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Utoma.Models;
using Microsoft.AspNetCore.Authorization;

namespace Utoma.Controllers
{
    [Authorize]
    public class PublishersController : Controller
    {
        private CatalogDbContext context;
        private IPublisherRepository repository;
        public PublishersController(CatalogDbContext _context, IPublisherRepository _repository)
        {
            context = _context;
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View(repository.publishers);
        }

        public IActionResult EditPublisher(int id)
        {
            return View(context.publishers.FirstOrDefault(p => p.PublisherId == id));
        }

        [HttpPost]
        public IActionResult EditPublisher(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                repository.UpdatePublisher(publisher);
                return RedirectToAction("Index");
            }
            return View(publisher);

        }

        public IActionResult AddPublisher()
        {
            return View("EditPublisher", new Publisher());
        }

        [HttpPost]
        public IActionResult AddPublisher(Publisher publisher)
        {
            repository.AddPublisher(publisher);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeletePublisher(Publisher publisher)
        {
            Publisher archName = context.publishers.FirstOrDefault(p => p.PublisherId == publisher.PublisherId);
            if (archName != null)
            {
                archName.PublisherName = string.Concat(publisher.PublisherName, "_(archive)");
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
