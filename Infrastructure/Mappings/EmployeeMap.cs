using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Rg).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(11);
            builder.Property(x => x.CellPhone).HasMaxLength(12);
            builder.Property(x => x.AdmissionDate).IsRequired();
            builder.Property(x => x.IsVeterinarian).IsRequired();
            builder.Property(x => x.Active).IsRequired().HasDefaultValueSql("1");
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");

            builder.HasIndex(x => x.Name);

            //builder
            //    .HasOne(e => e.Address)
            //    .WithMany(a => a.Employees)
            //    .HasForeignKey(e => e.AddressId);
        }
    }
}
