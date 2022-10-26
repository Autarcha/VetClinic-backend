using Microsoft.EntityFrameworkCore;
using VetClinic_backend.Enums;
using VetClinic_backend.Models;

namespace VetClinic_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<Adress>(a => a.Adress)
                .WithOne(u => u.User)
                .HasForeignKey<Adress>(a => a.Id);

            modelBuilder.Entity<Employee>()
                .HasOne<User>(u => u.User)
                .WithOne(e => e.Employee)
                .HasForeignKey<User>(u => u.Id);

            modelBuilder.Entity<Visit>()
                .HasOne<Examination>(e => e.Examination)
                .WithOne(v => v.Visit)
                .HasForeignKey<Examination>(e => e.Id);

            modelBuilder.Entity<Visit>()
                .HasOne<Animal>(a => a.Animal)
                .WithMany(v => v.Visits);

            modelBuilder.Entity<Visit>()
                .HasOne<Employee>(e => e.Employee)
                .WithMany(v => v.Visits);

            modelBuilder.Entity<Visit>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(v => v.Visits);

            modelBuilder.Entity<Animal>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(a => a.Animals);

            modelBuilder.Entity<Animal>()
                .HasOne<Specie>(s => s.Specie)
                .WithMany(a => a.Animals);

            modelBuilder.Entity<Examination>()
                .HasOne<Animal>(a => a.Animal)
                .WithMany(e => e.Examinations);

            modelBuilder.Entity<Examination>()
                .HasOne<Employee>(e => e.Employee)
                .WithMany(ex => ex.Examinations);

            modelBuilder.Entity<Examination>()
                .HasOne<Prescription>(p => p.Prescription)
                .WithOne(e => e.Examination)
                .HasForeignKey<Prescription>(p => p.Id);

            modelBuilder.Entity<Medicine>()
                .HasOne<Prescription>(p => p.Prescription)
                .WithMany(m => m.Medicines);
        }
    }
}
