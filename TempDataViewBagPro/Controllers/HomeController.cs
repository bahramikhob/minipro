using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempDataViewBagPro.Models;

namespace TempDataViewBagPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Count = 10;
            return View();
        }

        public IActionResult Index2()
        {
            var Count = ViewBag.Count;
            return View("Index");
        }

        //ViewBag===>write(viewBag.count=1)=>read(var x=viewBag.count)=>delete
        //TempData===>write(TempData["count"]=1)=>read(var x=TempData["count"])=>delete

        //TempData(keep)===>write(TempData["count"]=1)  =>  read(var x=TempData["count"]; TempData.keep("count")) =>read(var x=TempData["count"])=>delete
        //TempData(peek)===>write(TempData["count"]=1)  =>  read(var x=TempData.keep("count");) =>read(var x=TempData["count"])=>read(var x=TempData["count"])=>.....

        public IActionResult Index_writeTotempdata()
        {
            TempData["Count"] = 10;
            ViewBag.countx = 10;
            return View("tempdata");
        }

        public IActionResult Index_Keeptempdata()
        {
            var Count = TempData["Count"];

            if (2 == 2)
            {
                TempData.Keep("Count");  //method Keep: ouput type is void
            }
            else
            {

            }

            ViewBag.countx = Count;
            return View("tempdata");
        }
        public IActionResult Index_Peektempdata()
        {
            var Count = TempData.Peek("Count"); //method peek:ouput type is object
            ViewBag.countx = Count;
            return View("tempdata");
        }
        public IActionResult Index_Readtempdata()
        {
            var Count = TempData["Count"];
            ViewBag.countx = Count;
            return View("tempdata");
        }


    }
}
