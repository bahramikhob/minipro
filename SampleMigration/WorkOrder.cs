using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMigration
{
   public class WorkOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
        public string temp1 { get; set; }
        public string temp2 { get; set; }

        //Muted Fail =>  new List<Attachment>()
        public List<Attachment> Attachmentes { get; set; } = new List<Attachment>();
    }

    public class Attachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
    }

    public class MyContext : DbContext
    {
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Attachment> Attachment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=239;Persist Security Info=True;User ID=sa;Initial Catalog=mig;Data Source=.");
            base.OnConfiguring(optionsBuilder);
        }
    }
}   
