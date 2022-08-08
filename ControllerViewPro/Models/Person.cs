using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerViewPro.Models
{
    public class Person
    {
        public int id { get; set; }
        public string Name { get; set; }

        public string Get()
        {
            return "test injection";
        }
    }
}
