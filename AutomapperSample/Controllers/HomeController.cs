using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutomapperSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutomapperSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        public HomeController(ILogger<HomeController> logger, IMapper mapper)
        {
            _logger = logger;
            this.mapper = mapper;
        }

        public IActionResult personToPersonViewModel()
        {
            Person person = new Person() { ID = 1, Name = "Ali", Family = "Rezayee", Age = 30 };
            var vm = mapper.Map<PersonViewModel>(source: person);

            var result = vm.FullName;//note

            return View();
        }

        public IActionResult PersonViewModelToperson()
        {
            PersonViewModel vm = new PersonViewModel() { ID = 1, Name = "Ali", Family = "Rezayee", Age = 30 };
            var person = mapper.Map<Person>(source: vm);
            return View();
        }

        public IActionResult PersonViewModelTopersonExist()
        {         
            Person person = new Person() { ID = 1, Name = "Ali", Family = "Rezayee", Age = 30 };
            PersonViewModel vm = new PersonViewModel() { ID = 1, Name = "reza", Family = "ahmadi", Age = 20 };

            mapper.Map(vm, person);

            //کاربرد
            //var x=db.persons.find(100);
            //mapper.Map(vm, x);

            return View();
        }

        public IActionResult ListPersonToPersonViewModelList()
        {
            Category category1 = new Category() { ID = 1, Name = "cat01" };
            Category category2 = new Category() { ID = 1, Name = "cat02" };

            List<Person> listperson = new List<Person>();
            Person person1 = new Person() { ID = 1, Name = "Ali", Family = "Rezayee", Age = 30,Category=category1 };
            Person person2 = new Person() { ID = 2, Name = "Reza", Family = "jvadi", Age = 25,Category=category2 };

            listperson.Add(person1);
            listperson.Add(person2);


            //method 1
            var vm = listperson.Select(p => 
            {
                var v = mapper.Map<PersonViewModel>(source: p);
                return v;
            });

            //method 1  Best Practice
            var vm2 = listperson.AsQueryable().ProjectTo<PersonViewModel>(mapper.ConfigurationProvider).ToList();

            var result = vm2.FirstOrDefault().CategoryName;
            
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
