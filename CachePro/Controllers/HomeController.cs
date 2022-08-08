using CachePro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CachePro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        
        private readonly NewsRepository newsRepository;
        private readonly ICacheAdapter cacheAdapter;

        public HomeController(
            ILogger<HomeController> logger,
            NewsRepository newsRepository, 
            ICacheAdapter _cacheAdapter)
        {
            _logger = logger;
            this.newsRepository = newsRepository;
            cacheAdapter = _cacheAdapter;
        }

        public IActionResult Index()
        {
            var newsCount = cacheAdapter.Get<string>("NewsCount");
            if (string.IsNullOrEmpty(newsCount))
            {
                newsCount = newsRepository.GetNewCount().ToString();
                cacheAdapter.Set("NewsCount", newsCount);
            }

            ViewBag.newsCount = newsCount;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
