using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{

    public class DesignTimeContext : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Password=239;Persist Security Info=True;User ID=sa;Initial Catalog=Store;Data Source=.");
        return new StoreContext(builder.Options);
        }
    }
}
