using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfig
{
    public class KeyLessViewConfig : IEntityTypeConfiguration<KeyLessView>
    {
        public void Configure(EntityTypeBuilder<KeyLessView> builder)
        {
            builder.HasNoKey().ToView("vmPerson");
        }
    }
}
