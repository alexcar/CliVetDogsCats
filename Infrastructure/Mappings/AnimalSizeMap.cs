using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class AnimalSizeMap : IEntityTypeConfiguration<AnimalSize>
    {
        public void Configure(EntityTypeBuilder<AnimalSize> builder)
        {
            builder.ToTable("AnimalSize");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Active).IsRequired().HasDefaultValueSql("1");
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        }
    }
}
