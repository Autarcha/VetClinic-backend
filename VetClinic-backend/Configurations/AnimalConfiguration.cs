using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic_backend.Models;

namespace VetClinic_backend.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {

            builder.ToTable("users")
                .HasOne(x => x.Owner)
                .WithMany(x => x.Animals)
                .HasForeignKey("Owner_id");
                

            builder.ToTable("animals");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(x => x.Age)
                .HasColumnName("Age")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Specie)
                .HasColumnName("Specie")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

        }
    }
}
