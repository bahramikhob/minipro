using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions options) :base(options)
        {
                
        }
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Password=239;Persist Security Info=True;User ID=sa;Initial Catalog=DI;Data Source=.");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
