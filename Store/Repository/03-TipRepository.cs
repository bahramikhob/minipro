using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
   public class TipRepository
    {
        public static void GetByDbSET()
        {
            var db=ContextFactory.GetSqlContext();
            var result = db.Set<Discount>().ToList();
        }

        public static void RelationShipSimple()
        {
            //زمانی که از اس نو ترکینگ استفاده میکنیم اگر دوتا کلاس با هم ریلیشن داشته باشد، ریلیشن بین انها اتفاق نمی افتد
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Course.AsNoTracking().ToList();
            var discount = ctx.Set<Discount>().AsNoTracking().ToList();
        }

        public static void RelationShipNormal()
        {
            //زمانی که از اس نو ترکینگ استفاده نمیکنیم اگر دوتا کلاس با هم ریلیشن داشته باشند، ریلیشن بین انها اتفاق می افتد

            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Course.ToList();
            var discount = ctx.Set<Discount>().ToList();

        }




    }
}
