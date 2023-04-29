using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Hour).IsRequired().HasMaxLength(2);
            builder.Property(x => x.ScheduleDate).IsRequired();
            builder.Property(x => x.TutorComments).IsRequired().HasDefaultValueSql("100");
            builder.Property(x => x.ScheduleComments).IsRequired().HasDefaultValueSql("100");

            builder.Property(x => x.Active).IsRequired().HasDefaultValueSql("1");
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        }
    }
}
