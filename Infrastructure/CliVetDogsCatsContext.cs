using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class CliVetDogsCatsContext : DbContext
    {
        public CliVetDogsCatsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.NoAction);
            }

            modelBuilder.Entity<Schedule>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Schedules)
                .UsingEntity<ScheduleProduct>();

            modelBuilder.Entity<Schedule>()
                .HasMany(e => e.Services)
                .WithMany(e => e.Schedules)
                .UsingEntity<ScheduleService>();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductEntryHeader> ProductEntryHeaders { get; set; }
        public DbSet<ProductEntry> ProductEntries { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalSize> AnimalSizes { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Schedule> Schedules { get; set; }        
        public DbSet<ScheduleStatus> ScheduleStatus { get; set; }        
        public DbSet<ScheduleProduct> ScheduleProducts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ScheduleService> ScheduleServices { get; set; }

    }
}
