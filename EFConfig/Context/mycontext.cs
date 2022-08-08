using EFConfig._07_Shadow;
using EFConfig._08_Backing_Field;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFConfig
{
    public class mycontext : DbContext
    {
        public DbSet<PersonCoversion> PersonCoversions { get; set; }
        public DbSet<PersonAttr> PersonAttrs { get; set; }
        public DbSet<PersonFluentApi> PersonFluentApis { get; set; }
        public DbSet<KeyLessEntity> KeyLessEntitys { get; set; }
        public DbSet<KeyLessView> KeyLessViews { get; set; }
        public DbSet<PersonValueConversion> PersonValueConversions { get; set; }
        public DbSet<PersonShadow> PersonShadows { get; set; }
        public DbSet<StudentBackingField> StudentBackingFields { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=239;Persist Security Info=True;User ID=sa;Initial Catalog=config;Data Source=.");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
