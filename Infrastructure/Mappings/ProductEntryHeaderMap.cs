using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class ProductEntryHeaderMap : IEntityTypeConfiguration<ProductEntryHeader>
    {
        public void Configure(EntityTypeBuilder<ProductEntryHeader> builder)
        {
            builder.ToTable("ProductEntryHeader");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code).IsRequired().HasMaxLength(10);
            builder.Property(x => x.TransactionType).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Active).IsRequired().HasDefaultValueSql("1");
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        }
    }
}
