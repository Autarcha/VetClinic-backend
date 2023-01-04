using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic_backend.Models;

namespace VetClinic_backend.Configurations
{
    public class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {

            builder.ToTable("users")
                .HasOne(v => v.Employee)
                .WithMany(u => u.EmployeeVisits);

            builder.ToTable("users")
                .HasOne(v => v.Customer)
                .WithMany(u => u.CustomerVisits);

            builder.ToTable("animals")
                .HasOne(v => v.Animal)
                .WithMany(a => a.Visits)
                .HasForeignKey("AnimalId");

            builder.ToTable("visitDetails")
                .HasOne(v => v.VisitDetails)
                .WithOne(vd => vd.Visit);

            builder.ToTable("visits");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(v => v.VisitDateTime)
                .HasColumnName("VisitDateTime")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(v => v.VisitStatus)
                .HasColumnName("VisitStatus")
                .HasColumnType("int")
                .IsRequired();

        }
    }
}
