using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace EFConfig
{
    public class PersonConfig : IEntityTypeConfiguration<PersonFluentApi>
    {
        public void Configure(EntityTypeBuilder<PersonFluentApi> builder)
        {
            builder.ToTable("PersonFlunts", "Edari");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasColumnType("nvarchar(50)");
            builder.Ignore(p => p.FullName);
        }
    }
}
