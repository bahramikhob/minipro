using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomapperSample.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }


    public class Category
    {
        public int ID { get; set; }
       
        public string Name { get; set; }
         
        public List<Person> Person{ get; set; }

    }


    public class PersonViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Family { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string CategoryName { get; set; }

    }


}
