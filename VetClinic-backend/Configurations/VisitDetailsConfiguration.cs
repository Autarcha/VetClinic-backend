using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic_backend.Models;

namespace VetClinic_backend.Configurations
{
    public class VisitDetailsConfiguration: IEntityTypeConfiguration<VisitDetails>
    {
        public void Configure(EntityTypeBuilder<VisitDetails> builder)
        {

            builder.ToTable("visitDetails")
                .HasOne(vd => vd.Visit)
                .WithOne(v => v.VisitDetails)
                .HasForeignKey("Visit_id");

            builder.ToTable("visitDetails");

            builder.HasKey(vd => vd.Id);

            builder.Property(vd => vd.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(vd => vd.VisitPurpose)
                .HasColumnName("VisitPurpose")
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(vd => vd.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(vd => vd.AppliedDrugs)
                .HasColumnName("AppliedDrugs")
                .HasColumnType("varchar(MAX)");

            builder.Property(vd => vd.Prescription)
                .HasColumnName("Prescription")
                .HasColumnType("varchar(MAX)");

            builder.Property(vd => vd.Recommendations)
                .HasColumnName("Recommendations")
                .HasColumnType("varchar(MAX)");
        }
    }
}
