using Microsoft.EntityFrameworkCore;
using Store.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
   public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<CourseTeacher> CourseTeacher { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Discount> Discount{ get; set; }


        public DbSet<Employee> Employees { get; set; }


        public DbSet<Parent> Parent { get; set; }
        public DbSet<Child01> Child01 { get; set; }
        public DbSet<Child02> Child02 { get; set; }
        public DbSet<Child03> Child03 { get; set; }


        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Attachment> Attachments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Password=239;Persist Security Info=True;User ID=sa;Initial Catalog=Store;Data Source=.");
            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


    }
}
