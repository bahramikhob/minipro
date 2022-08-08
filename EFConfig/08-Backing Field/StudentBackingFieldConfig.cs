using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfig._08_Backing_Field
{
    public class StudentBackingFieldConfig : IEntityTypeConfiguration<StudentBackingField>
    {
        public void Configure(EntityTypeBuilder<StudentBackingField> builder)
        {
            builder.Property(c => c.LastName).HasField("_myBackingFieldForLastName");
           // builder.Property<string>("StudentNumber").HasField("_studentNumber");
           
        }
    }
}
