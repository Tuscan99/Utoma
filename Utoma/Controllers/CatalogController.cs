using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Utoma.Models;
using Utoma.Models.ViewModels;

namespace Utoma.Controllers
{
    public class CatalogController : Controller
    {
        private CatalogDbContext context;
        public CatalogController(CatalogDbContext _context)
        {
            context = _context;
        }

        public IActionResult List(string category)
        {

            return View(new ListViewModel
            {
                periodicalsToPage = context.periodicals
                .Where(p => category == null || p.Category.CategoryName == category)
                .OrderBy(p => p.Id),

                categoriesToPage = context.categories,

                selectedCategory = category
            });
        }

        public IActionResult Details(int id)
        {
            ViewBag.Categories = context.categories;

            return View(context.periodicals
                .Include(p => p.Category)
                .Include(p => p.PublicationType)
                .Include(p => p.Publisher)
                .FirstOrDefault(p => p.Id == id));

        }

        public IActionResult Thanks()
        {
            ViewBag.Categories = context.categories;
            return View();
        }
    }
}
