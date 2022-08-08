using DI.Domain;
using DI.Models;
using DI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonRepository personRepository;
        private readonly Services services;

        public HomeController(ILogger<HomeController> logger, IPersonRepository personRepository,Services services)
        {
            _logger = logger;
            this.personRepository = personRepository;
            this.services = services;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ServiceLocator()
        {
          var service=  HttpContext.RequestServices.GetRequiredService<IPersonRepository>();
            Person person = new Person
            {
                Age = 20,
                FirstName = "ali",
                LastName = "jvadi"
            };
            service.AddPerson(person);
            return View();
        }

        public IActionResult add()
        {
            Person person = new Person
            {
                Age = 20,
                FirstName = "ali",
                LastName = "jvadi"
            };
            personRepository.AddPerson(person);
            return View();
        }

        public IActionResult GetService()
        {
           var result= services.Get();
            //  var t = HttpContext.RequestServices.GetService<TestManager>();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
