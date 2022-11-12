using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VetClinic_backend.Models;

namespace VetClinic_backend.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        //Configuration for users table
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasColumnName("Surname")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName("Role")
                .HasColumnType("int")
                .HasDefaultValue(Role.User);

        }
    }
}
