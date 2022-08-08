using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace EFConfig
{
    public class PersonConfigValueConversion : IEntityTypeConfiguration<PersonValueConversion>
    {
        public void Configure(EntityTypeBuilder<PersonValueConversion> builder)
        {
             //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations
            //A:
            //Value  Conversion
            //builder.Property(p => p.TypePerson).HasConversion<string>().HasMaxLength(20);//Enum to string

            //B:
            builder.Property(p => p.TypePerson).HasConversion(
            v => v.ToString(),
            v => (TypePerson)Enum.Parse(typeof(TypePerson), v));

            //c:
            var converter = new ValueConverter<TypePerson, string>(
        v => v.ToString(),//save in database by string
        v => (TypePerson)Enum.Parse(typeof(TypePerson), v));//read of database by enum type TypePerson
            builder.Property(p => p.TypePerson).HasConversion(converter);

            //Builting convertor
            var converter1 = new BoolToZeroOneConverter<int>();
            builder.Property(e => e.IsActive).HasConversion(converter1);
            //با بالایی معادل هم هستند 
            builder.Property(e => e.IsActive).HasConversion<int>();
            
            builder.Property(e => e.password).HasConversion(new EncryptedConverter());


        }
    }
}
