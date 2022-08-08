using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
   public class TipRepository
    {
        public static void CheckAddEntity()
        {
            var ctx = ContextFactory.GetSqlContext();

            var course = ctx.Course.FirstOrDefault(c => c.Id == 1);
            var discoutn = new Discount
            {
                CourseId = 2,
                Name = "Discount02",
                NewPrice = 10
            };

            ctx.Add(discoutn);
            //بعد از متد اد اگر به ابجکت دوره نگاه کنیم میبینیم عملیات ریلیشن فیکس آپ رخ داده
            //و پراپرتی دیسکانت  مقدار بالا گرفته
            //پس به این نتیجه میرسیم حتی با اد کردن بدون سیو چنج عملیات فیکس آپ نرمال و دتکچنچ رخ داده پس همینجوری عملیات اد انجام ندیم


            int a = 1;

        }

        public static void CopyCourse(int courseId)
        {
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Course.AsNoTrackingWithIdentityResolution()
                .Include(c => c.Discount)
                .Include(c => c.Comments)
                .Include(c => c.Tags)
                .Include(c => c.CourseTeachers)
                .FirstOrDefault(c => c.Id == courseId);

            //set id =0;
            ctx.Add(course);
            ctx.SaveChanges();
        }

        public static void DeleteDiscount(int id)
        {
            var ctx = ContextFactory.GetSqlContext();
            //var discount = ctx.Set<Discount>().FirstOrDefault(c => c.Id == id);
            var discount = new Discount
            {
                Id = id
            };
            ctx.Remove(discount);
        }
    }
}
