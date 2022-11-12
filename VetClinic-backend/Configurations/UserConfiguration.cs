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
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasColumnName("name")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName("role")
                .HasColumnType("int")
                .HasDefaultValue(Role.User);

        }
    }
}
