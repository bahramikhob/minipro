using EFConfig._07_Shadow;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // TestValueConversion();
            // TestKeyLess();

            IOShadow();

            Console.ReadLine();
        }

        private static void IOShadow()
        {
            mycontext db = new mycontext();
            var obj = new PersonShadow
            {
                FirstName = "reza",
                LastName = "jevadi",
                Age = 20,
            };
            // sets the value to the shadow property
            db.Entry(obj).Property("DateCreate").CurrentValue = "1400/02/23";
            db.PersonShadows.Add(obj);
            db.SaveChanges();


            //Note: shadow property only work by changetracker 
            //sample under result is null
            var query1 = db.PersonShadows.AsNoTracking().FirstOrDefault();
            var getcreatedDate = db.Entry(query1).Property("DateCreate").CurrentValue;
           

            var query = db.PersonShadows.FirstOrDefault();
            // gets the value of the shadow property
            var createdDate = db.Entry(query).Property("DateCreate").CurrentValue;


            var query3 = db.PersonShadows.Where(p => EF.Property<string>(p,"DateCreate") == "1400/02/23");

            foreach (var item in query3)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        private static void TestKeyLess()
        {
            //add view to migration
            mycontext db = new mycontext();
            var keylessEntity = db.KeyLessEntitys.ToList();
            var keylessView = db.KeyLessViews.ToList();
        }

        private static void TestValueConversion()
        {
            mycontext db = new mycontext();
            db.PersonValueConversions.Add(new PersonValueConversion
            {
                FirstName = "ali",
                LastName = "amiri",
                Age = 20,
                TypePerson = TypePerson.child
            });
            db.SaveChanges();

            var query = db.PersonValueConversions.ToList();
        }
    }
}
