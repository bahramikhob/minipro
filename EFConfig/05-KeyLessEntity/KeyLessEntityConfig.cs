using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfig
{
    public class KeyLessEntityConfig : IEntityTypeConfiguration<KeyLessEntity>
    {
        public void Configure(EntityTypeBuilder<KeyLessEntity> builder)
        {
            builder.HasNoKey();
        }
    }
}
