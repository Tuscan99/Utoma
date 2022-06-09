using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Utoma.Models;
using Utoma.Models.ViewModels;

namespace Utoma.Controllers
{
    public class HomeController : Controller
    {

        private CatalogDbContext context;
        public HomeController(CatalogDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View(context.periodicals.Take(8));
        }

        public IActionResult Contact()
        {
            return View();
        }

    }
}
