using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class MutedFail
    {
        public static void Get()
        {
            // در صورتی یک دستور کار فایل ضمیمه نداشته باشد
            // مقدار اتچمنت آن نال نیست و مقدارکانت آن برابر  صفر است
            //دلیل این کار استفاده از
            //Muted Fail=> public List<Attachment> Attachmentes { get; set; } = new List<Attachment>();
            var db = ContextFactory.GetSqlContext();
            var x = db.WorkOrders.Include(p => p.Attachmentes).ToList();

        }
    }
}
