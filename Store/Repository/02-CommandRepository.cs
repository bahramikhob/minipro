using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class CommandRepository
    {
        public static void CreateCourse(string title, string description, int price)
        {
            var course = new Course
            {
                Title = title,
                Description = description,
                Price = price
            };

            var ctx = ContextFactory.GetSqlContext();
            //ctx.Add(course);
            ctx.Course.Add(course);
            ctx.SaveChanges();
        }
        public static void CreateCourseWithDiscount(string title, string description, int price, int discountPrice, string discountTitle)
        {
            var course = new Course
            {
                Title = title,
                Description = description,
                Price = price,
                Discount = new Discount
                {
                    Name = discountTitle,
                    NewPrice = discountPrice
                }
            };

            var ctx = ContextFactory.GetSqlContext();
            //ctx.Add(course);
            ctx.Course.Add(course);
            Console.WriteLine(ctx.ChangeTracker.DebugView.LongView);
            ctx.SaveChanges();
            Console.WriteLine(ctx.ChangeTracker.DebugView.LongView);

        }
        public static void Update(int courseId, string newTitle)
        {
            var ctx = ContextFactory.GetSqlContext();
            //var course1 = ctx.Courses.Find(courseId);
            // var course2 = ctx.Courses.FirstOrDefault(c=>c.Id == courseId);
            var course = ctx.Course.SingleOrDefault(c => c.Id == courseId);
            course.Title = newTitle;
            ctx.SaveChanges();
        }
        public static void ShowForUpdateDisconnected(int courseId)
        {
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Course.SingleOrDefault(c => c.Id == courseId);

            Console.WriteLine($"{course.Id}: {course.Title} {Environment.NewLine} {course.Description}");

            UpdateDisconnected(courseId, "New Title");
        }
        private static void UpdateDisconnected(int courseId, string title)
        {
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Course.SingleOrDefault(c => c.Id == courseId);
            course.Title = title;
            ctx.SaveChanges();
        }
        public static void ShowForUpdateDisconnectedTag(int tagId)
        {
            var ctx = ContextFactory.GetSqlContext();
            var tag = ctx.Tag.SingleOrDefault(c => c.Id == tagId);

            Console.WriteLine($"{tag.Id}: {tag.Title}");

            UpdateDisconnectedTag(tag.Id, "New Title");
        }
        public static void UpdateDisconnectedTag(int id, string title)
        {
            var ctx = ContextFactory.GetSqlContext();
            var tag = new Tag
            {
                Id = id,
                Title = title
            };
            ctx.Tag.Update(tag);
            ctx.SaveChanges();

        }


        public static void EditCourseGet(int courseId)
        {
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Course.SingleOrDefault(c => c.Id == courseId);
            course.Title = "asp .net";
            Console.WriteLine($"{course.Id}: {course.Title} {Environment.NewLine} {course.Description}");

            EditCoursePost(course);
        }
        private static void EditCoursePost(Course course)
        {
            var ctx = ContextFactory.GetSqlContext();
            ctx.Update(course);
            ctx.SaveChanges();
        }

        public static void SoftDelete(int courseId)
        {
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Course.SingleOrDefault(c => c.Id == courseId);
            course.IsDeleted = true;
            ctx.SaveChanges();
        }
        public static void Delete(int courseId)
        {
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Course.SingleOrDefault(c => c.Id == courseId);
            ctx.Course.Remove(course);
            ctx.SaveChanges();
        }




    }
}
