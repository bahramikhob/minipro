using DI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContext db;
        public PersonRepository(MyContext myContext)
        {
            db = myContext;
        }
        public void AddPerson(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }
    }
}
