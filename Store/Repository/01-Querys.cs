using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
   public class Querys
    {

        public static void AddDefaultData()
        {
            var context = ContextFactory.GetSqlContext();
            context.Course.Where(c => c.Title == "");
            context.Course.Add(new Course
            {
                Title = "Pro ASP.NET Core",
                Price = 100,
                Description = "Description ASP Net Core",
                Discount = new Discount
                {
                    Name = "Yalda",
                    NewPrice = 80
                },
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Title = "Comment Title",
                        CommentDate = DateTime.Now,
                        CommentText = "Comment Text"
                    }
                },
                CourseTeachers = new List<CourseTeacher>
                {
                    new CourseTeacher
                    {
                        SortOrder = 1,
                        Teacher = new Teacher
                        {
                            FirstName= "Alireza",
                            LastName = "Oroumand"
                        }
                    }
                },
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Title = "ASP.NET"
                    },
                    new Tag
                    {
                        Title = ".NET 5"
                    }
                }
            });
            context.SaveChanges();
        }

        public static void EagerLoadingSample01()
        {
            var ctx = ContextFactory.GetSqlContext();

            var query = ctx.Course
                .Include(c => c.Discount)
                .Include(c => c.Comments)
                .Include(c => c.CourseTeachers).ThenInclude(d => d.Teacher)
                .Include(c => c.Tags);

            var queryString = query.ToQueryString();

            var result = query.ToList();

        }

        public static void EagerLoadingSample02()
        {
            var ctx = ContextFactory.GetSqlContext();

            var query = ctx.Course
                .Include(c => c.Discount)
                .Include(c => c.Comments.Where(c => c.CommentDate >= DateTime.Now.AddDays(-10)))
                .Include(c => c.CourseTeachers.OrderBy(c => c.SortOrder)).ThenInclude(d => d.Teacher)
                .Include(c => c.Tags);
            var queryString = query.ToQueryString();
            var result = query.ToList();

        }

        public static void ExplicitLoading()
        {
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Course.FirstAsync();

            ctx.Entry(course).Reference("Discount").Load();

            ctx.Entry(course).Collection("Tags").Load();
        }

        public static void SelectLoading()
        {
            var ctx = ContextFactory.GetSqlContext();

            var course = ctx.Course.Select(c => new
            {
                Title = c.Title,
                Price = c.Price,
                // methods=c.gettitle(),
                NewPricex = c.Discount.NewPrice,
                PriceTitle = c.Discount.Name,
                CommentCount = c.Comments.Where(p => p.Title.StartsWith("tr")).Count(),
                //Tags = string.Join(',', c.Tags.Select(d => d.Title)),  //run in RAM,

            });

            var queryString = course.ToQueryString();
            var res = course.ToList();

        }

        public static void ClientVsServerAfter03()
        {
            var ctx = ContextFactory.GetSqlContext();
            var result = ctx.Course.Select(c => new
            {
                A = 22, //run in RAM
                A0 = c.Title,        //run in SQL
                A1 = 22 + c.Title,     //run in SQL
                A2 = c.Title + 22, //run in SQL
                A3 = c.Title + Convert.ToInt32(23),    //run in SQL

                B = Course.StaticMethod(), //run in RAM
                B1 = Course.StaticMethod() + c.Title,  //run in SQL
                B2 = c.Title + Course.StaticMethod(),  //run in SQL

                G = c.Title + " b " + c.LocalMethod(),  //(c.Title+" b ")run in SQL &  (+c.gettitle2()) run in RAM
                H = c.LocalMethod() + " x " + c.Title + c.LocalMethod(),   //run in RAM
                M = c.LocalMethod() + c.Title,   //run in RAM
                N = c.FullName,     //run in RAM
                Tags = string.Join(',', c.Tags.Select(d => d.Title)),  //run in RAM,


                AA = (c.Title != null ? c.Title.StartsWith("pro") == true ? c.Title + " pro " : "no pro" : "null"),

            });

            var queryString = result.ToQueryString();
            var a = result.ToList();
        }

        public static void ClientVsServerBefore3()
        {
            var ctx = ContextFactory.GetSqlContext();
            var result = ctx.Teacher.OrderBy(c => c.FullName).Skip(0).Take(10).ToList();//error
            // var queryString = result.ToQueryString();
        }

        public static void SortOrder(bool asc)
        {
            var ctx = ContextFactory.GetSqlContext();
            if (asc)
            {
                var course = ctx.Course.OrderBy(c => c.Price).ThenBy(c => c.Title).ToList();
            }
            else
            {
                var course = ctx.Course.OrderByDescending(c => c.Price).ThenByDescending(c => c.Title).ToList();
            }
        }

        public static void Paging(int pageSize, int pageIndex)
        {
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Course.OrderBy(c => c.Title).Skip(pageIndex * pageSize).Take(pageSize);
            var queryString = course.ToQueryString();
        }

        public static void SearchText(string term)
        {
            var ctx = ContextFactory.GetSqlContext();
            
            var result01 = ctx.Course.Where(c => c.Title.StartsWith(term));
            var result02 = ctx.Course.Where(c => c.Title.Contains(term));
            var result03 = ctx.Course.Where(c => c.Title == term);

            var result04 = ctx.Course
                .Where(x => EF.Functions.Collate(x.Title, "Latin1_General_CS_AS") == term);
            var queryString = result04.ToQueryString();

            var result05 = ctx.Course.Where(c => EF.Functions.Like(c.Title, "The ___ sat on the %."));
            var queryString2 = result05.ToQueryString();

        }

        public static void CheckEntityState()
        {
            var ctx = ContextFactory.GetSqlContext();
            var teacher = new Teacher
            {
                FirstName = "Masoud",
                LastName = "Taheri"
            };
            ctx.Add(teacher);
            Console.WriteLine($"Teacher State Is : {ctx.Entry(teacher).State}");//added

            var course = ctx.Course.FirstOrDefault();
            Console.WriteLine($"Course State Before Change Is: {ctx.Entry(course).State}");//unchanged

            course.Title = "Pro Ef And ASP.NET Core";
            Console.WriteLine($"Course State Before Change Is:  {ctx.Entry(course).State}");//modified

            ctx.Remove(course);
            Console.WriteLine($"Course State After Remove Is:  {ctx.Entry(course).State}");//deleted

            var tag = new Tag
            {
                Title = "New Tag"
            };

            Console.WriteLine($"Tag State :  {ctx.Entry(tag).State}");//Detached
        }


    }




}

