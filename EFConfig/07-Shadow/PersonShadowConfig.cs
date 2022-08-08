using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfig._07_Shadow
{
    public class PersonShadowConfig : IEntityTypeConfiguration<PersonShadow>
    {
        public void Configure(EntityTypeBuilder<PersonShadow> builder)
        {
            builder.Property<string>("DateCreate").HasMaxLength(10);
            builder.Property<string>("TimeCreate").HasMaxLength(10);
            builder.Property<int>("PersonCreate").HasMaxLength(10);
            builder.Property<string>("PersonNameCreate").HasMaxLength(50);

            //https://www.entityframeworktutorial.net/efcore/shadow-property.aspx


            //in Context
            //    public override int SaveChanges()
            //{
            //    var entries = ChangeTracker
            //        .Entries()
            //        .Where(e =>
            //                e.State == EntityState.Added
            //                || e.State == EntityState.Modified);

            //    foreach (var entityEntry in entries)
            //    {
            //        entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

            //        if (entityEntry.State == EntityState.Added)
            //        {
            //            entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
            //        }
            //    }

            //    return base.SaveChanges();
            //}


            //add shadow property for all entites
            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    var allEntities = modelBuilder.Model.GetEntityTypes();

            //    foreach (var entity in allEntities)
            //    {
            //        entity.AddProperty("CreatedDate", typeof(DateTime));
            //        entity.AddProperty("UpdatedDate", typeof(DateTime));
            //    }
            //}

            //or
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    modelBuilder.Entity(entityType.ClrType).Property<int>("AutoShadow");
            //}
        }
}
}
