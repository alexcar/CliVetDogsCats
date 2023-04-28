using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class TutorMap : IEntityTypeConfiguration<Tutor>
    {
        public void Configure(EntityTypeBuilder<Tutor> builder)
        {
            builder.ToTable("Tutor");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Rg).IsRequired().HasMaxLength(15);            
            builder.Property(x => x.Phone).HasMaxLength(11);
            builder.Property(x => x.CellPhone).IsRequired().HasMaxLength(12);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DayMonthBirth).HasMaxLength(7);
            builder.Property(x => x.Comments).HasMaxLength(300);
            builder.Property(x => x.Active).IsRequired().HasDefaultValueSql("1");
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        }
    }
}
