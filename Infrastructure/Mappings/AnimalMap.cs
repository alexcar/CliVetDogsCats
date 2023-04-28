using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animal");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Coat).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Sexo).IsRequired().HasMaxLength(1);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Weigth).IsRequired().HasColumnType("decimal(18,4)");
            builder.Property(x => x.Comments).HasMaxLength(100);
            builder.Property(x => x.Active).IsRequired().HasDefaultValueSql("1");
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        }
    }
}
