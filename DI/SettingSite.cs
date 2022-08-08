using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI
{
    public class SettingSite
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public subclass subclass { get; set; }
    }

    public class subclass
    {
        public string SubName { get; set; }
    }
}
