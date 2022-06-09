using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using Utoma.Models;
using Utoma.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Utoma.Controllers
{
    public class NewsController : Controller
    {
        private CatalogDbContext context;
        private INewsRepository repository;
        public NewsController(CatalogDbContext _context, INewsRepository _repository)
        {
            context = _context;
            repository = _repository;
        }

        static string urlTech = "https://www.theverge.com/tech/rss/index.xml";
        static string urlHealth = "https://www.theverge.com/rss/health/index.xml";
        static string urlCulture = "https://www.theverge.com/culture/rss/index.xml";
        static string url2 = "https://news.mail.ru/rss/society/91/";

        SyndicationFeed feed = null;
        static string url = url2;

        List<News> buffer = new List<News>();

        public IActionResult Index()
        {
            try
            {
                using (var reader = XmlReader.Create(url))
                {
                    feed = SyndicationFeed.Load(reader);
                }

            }
            catch
            {
                return View("Unavailable");
            }


            return View(feed);
        }

        public IActionResult CheckoutNews()
        {
            int numberOfRecords = 0;
            numberOfRecords = context.newsArticles.Count();
            IEnumerable<News> recordsToRemove = context.newsArticles.Take(16);
            if (numberOfRecords > 24)
            {
                context.newsArticles.RemoveRange(recordsToRemove);
                context.SaveChanges();
            }

            try
            {
                using (var reader = XmlReader.Create(url))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            catch
            {
                return View("Unavailable");
            }

            foreach(SyndicationItem item in feed.Items)
            {
                buffer.Add(new News()
                {
                    Title = item.Title.Text,
                    PublishDate = item.PublishDate.ToString(),
                    Author = item.Authors.DefaultIfEmpty(new SyndicationPerson { Name = "" }).FirstOrDefault().Name,
                    NewsCategory = item.Categories.DefaultIfEmpty(new SyndicationCategory { Name = "other" }).FirstOrDefault().Name,
                    NewsDescription = item.Summary?.Text ?? "",
                    Link = item.Links.FirstOrDefault().Uri.ToString()
                });
            }
            IEnumerable<News> rangetoview = buffer.TakeLast(8).ToList();
            context.newsArticles.AddRange(rangetoview);
            context.SaveChanges();

            return View("StoredNews", context.newsArticles);
        }

        //[HttpPost]
        //public IActionResult AddNews()
        //{
        //    return View();
        //}

        public IActionResult StoredNews()
        {
            return View(context.newsArticles);
        }

        public IActionResult EditNews(int id)
        {
            return View(context.newsArticles.FirstOrDefault(n => n.newsId == id));
        }

        [HttpPost]
        public IActionResult EditNews(News newsArticle)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateNews(newsArticle);
                return RedirectToAction("StoredNews");
            }
            return View(newsArticle);
        }

        [HttpPost]
        public IActionResult DeleteNews(int Id)
        {
            News newsArticleToDel = repository.DeleteNews(Id);
            return RedirectToAction("StoredNews");
        }
    }
}
