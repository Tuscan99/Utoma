using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Utoma.Models;
using Utoma.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Utoma.Controllers
{
    [Authorize]
    public class SubscriptionController : Controller
    {
        private CatalogDbContext context;
        private ISubscriptionRepository repository;
        public SubscriptionController(CatalogDbContext _context, ISubscriptionRepository _repository)
        {
            context = _context;
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View(repository.subscriptions.Include(s => s.Periodical));
        }

        public IActionResult EditSubscription(int id)
        {
            return View(context.subscriptions.FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        public IActionResult EditSubscription(Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateSubscription(subscription);
                return RedirectToAction("Index");
            }
            return View(subscription);

        }

        [AllowAnonymous]
        public IActionResult AddSubscription(int magId)
        {
            IEnumerable<string> Cities = new List<string>
            {
                "Utopia",
                "Foresight",
                "Malta"
            };
            ViewBag.cts = Cities;

            Periodical mag = context.periodicals.FirstOrDefault(p => p.Id == magId);
            ViewBag.Mag = mag;

            return View(new Subscription()
            {
                PeriodicalId = magId
                
            });
        }


        //from Catalog/Details
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddSubscription(Subscription subscription)
        {
            IEnumerable<string> Cities = new List<string>
            {
                "Utopia",
                "Foresight",
                "Malta"
            };
            ViewBag.cts = Cities;

            if (ModelState.IsValid)
            {
                repository.AddSubscription(subscription);
                return RedirectToAction("Thanks", "Catalog");
            }
            else
            {
                Periodical mag = context.periodicals.FirstOrDefault(p => p.Id == subscription.PeriodicalId);
                ViewBag.Mag = mag;
                return View(new Subscription()
                {
                    PeriodicalId = subscription.PeriodicalId

                });

            }
        }

        [HttpPost]
        public IActionResult DeleteSubscription(int subscriptionId)
        {
            Subscription subscriptionToDel = repository.DeleteSubscription(subscriptionId);
            
            return RedirectToAction("Index");
        }

        
    }
}
