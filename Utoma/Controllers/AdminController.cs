using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Utoma.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Utoma.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private CatalogDbContext context;
        private IPeriodicalRepository periodicalRepository;
        public AdminController(CatalogDbContext _context, IPeriodicalRepository _periodicalRepository)
        {
            context = _context;
            periodicalRepository = _periodicalRepository;
        }
        public void setVB()
        {
            ViewBag.Categories = context.categories;
            ViewBag.PTypes = context.publicationTypes;
            ViewBag.Publishers = context.publishers;
        }


        public IActionResult Index()
        {
            return View(context.periodicals
                .Include(p => p.Category)
                .Include(p => p.PublicationType)
                .Include(p => p.Publisher)
            );
        }

        public IActionResult Edit(int _id)
        {
            setVB();

            return View(context.periodicals
                .Include(p => p.Category)
                .Include(p => p.PublicationType)
                .Include(p => p.Publisher)
                .FirstOrDefault(p => p.Id == _id));
        }

        [HttpPost]
        public IActionResult Edit(Periodical periodical)
        {
            if (ModelState.IsValid)
            {
                periodicalRepository.SavePeriodical(periodical);
                return RedirectToAction("Index");
            }
            else
            {
                setVB();
                return View(periodical);
            }
        }

        public IActionResult Create()
        {
            setVB();

            return View(new Periodical());
        }

        [HttpPost]
        public IActionResult Create(Periodical periodical)
        {
            if (ModelState.IsValid)
            {
                periodicalRepository.SavePeriodical(periodical);
                return RedirectToAction("Index");
            }
            else
            {
                setVB();
                return View(new Periodical());
            }
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Periodical periodicalToDel = periodicalRepository.DeletePeriodical(Id);
            return RedirectToAction("Index");
        }
    }
}
