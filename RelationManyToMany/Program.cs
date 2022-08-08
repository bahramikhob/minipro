using Microsoft.EntityFrameworkCore;
using RelationManyToMany.Model;
using System;
using System.Linq;

namespace RelationManyToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //WriteToCourse();
            //GetAllCourse();
            //UpdateCourse();
        }
        private static void WriteToCourse()
        {
            using (MyContext db = new MyContext())
            {
                var query = db.courses.Where(p => p.Title.EndsWith("mm") && p.Title.StartsWith(".net"));
                var viewQuery = query.ToQueryString();

                var course = new Course()
                {
                    Title = "c#",
                    Tags = new System.Collections.Generic.List<Tag>
                    {
                        new Tag
                        {
                            Name="TagC#"
                        },new Tag
                        {
                            Name="AspTag"
                        }
                    }
                };

                db.courses.Add(course);
                //db.Add(course);  Ctrl+K+C  comment
                db.SaveChanges();

            }
        }
        private static void GetAllCourse()
        {
            using (MyContext db = new MyContext())
            {
                var query = db.courses.Include(p=>p.Tags).AsNoTracking();
                var viewQuery = query.ToQueryString();
                foreach (var course in query)
                {
                    Console.WriteLine($"{course.Id}: {course.Title}, {course.Price}");
                    Console.WriteLine("".PadLeft(100, '-'));
                }
            }
        } 
        private static void UpdateCourse()
        {
            using (MyContext db = new MyContext())
            {
                var query = db.courses.Find(1);
               // var viewQuery = query.ToQueryString();
                query.Title += " test";
                db.SaveChanges();
            }
        } 
    }
}
