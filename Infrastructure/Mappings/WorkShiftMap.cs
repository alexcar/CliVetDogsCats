using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class WorkShiftMap : IEntityTypeConfiguration<WorkShift>
    {
        public void Configure(EntityTypeBuilder<WorkShift> builder)
        {
            builder.ToTable(nameof(WorkShift));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Monday).IsRequired();
            builder.Property(x => x.Tuesday).IsRequired();
            builder.Property(x => x.Wednesday).IsRequired();
            builder.Property(x => x.Thursday).IsRequired();
            builder.Property(x => x.Friday).IsRequired();
            builder.Property(x => x.Saturday).IsRequired();
            builder.Property(x => x.Sunday).IsRequired();
            builder.Property(x => x.Active).IsRequired().HasDefaultValueSql("1");
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        }
    }
}
