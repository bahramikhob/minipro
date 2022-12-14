using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ParenId { get; set; }
        public bool Is { get; set; }
        public List<Employee> Children { get; set; }
    }

    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Child01> Child01s { get; set; }
        public List<Child02> Child02s { get; set; }
        public List<Child03> Child03s { get; set; }
    }

    public class Child01
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Child02
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class Child03
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
