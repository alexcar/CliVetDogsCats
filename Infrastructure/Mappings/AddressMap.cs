using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(9);
            builder.Property(x => x.StreetAddress).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Number).IsRequired().HasMaxLength(7);
            builder.Property(x => x.Complement).HasMaxLength(40);
            builder.Property(x => x.Neighborhood).IsRequired().HasMaxLength(30);
            builder.Property(x => x.City).IsRequired().HasMaxLength(30);
            builder.Property(x => x.State).IsRequired().HasMaxLength(2);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Active).IsRequired().HasDefaultValueSql("1");
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");

            builder.HasIndex(x => x.ZipCode);            
        }
    }    
}
