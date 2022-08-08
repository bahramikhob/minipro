using Microsoft.EntityFrameworkCore;
using Store.Models;
using System;

namespace Store
{
    internal class ContextFactory
    {
        internal static StoreContext GetSqlContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            
            optionsBuilder.UseSqlServer("Password=239;Persist Security Info=True;User ID=sa;Initial Catalog=Store;Data Source=.");//
            //,c=>c.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));


           // optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
            var context = new StoreContext(optionsBuilder.Options);
            return context;
        }
    }
}