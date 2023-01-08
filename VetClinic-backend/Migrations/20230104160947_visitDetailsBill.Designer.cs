﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetClinic_backend.Data;

#nullable disable

namespace VetClinic_backend.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230104160947_visitDetailsBill")]
    partial class visitDetailsBill
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VetClinic_backend.Models.Animal", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("AdditionalInfo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name");

                    b.Property<int>("Owner_id")
                        .HasColumnType("int");

                    b.Property<string>("Specie")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("Specie");

                    b.HasKey("Id");

                    b.HasIndex("Owner_id");

                    b.ToTable("animals", (string)null);
                });

            modelBuilder.Entity("VetClinic_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(4)
                        .HasColumnName("Role");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Surname");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("VetClinic_backend.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("VisitDateTime");

                    b.Property<int?>("VisitDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("VisitStatus")
                        .HasColumnType("int")
                        .HasColumnName("VisitStatus");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VisitDetailsId")
                        .IsUnique()
                        .HasFilter("[VisitDetailsId] IS NOT NULL");

                    b.ToTable("visits", (string)null);
                });

            modelBuilder.Entity("VetClinic_backend.Models.VisitDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppliedDrugs")
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("AppliedDrugs");

                    b.Property<double>("Bill")
                        .HasColumnType("double precision")
                        .HasColumnName("Bill");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("Description");

                    b.Property<string>("Prescription")
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("Prescription");

                    b.Property<string>("Recommendations")
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("Recommendations");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.Property<string>("VisitPurpose")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasColumnName("VisitPurpose");

                    b.HasKey("Id");

                    b.ToTable("visitDetails", (string)null);
                });

            modelBuilder.Entity("VetClinic_backend.Models.Animal", b =>
                {
                    b.HasOne("VetClinic_backend.Models.User", "Owner")
                        .WithMany("Animals")
                        .HasForeignKey("Owner_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("VetClinic_backend.Models.Visit", b =>
                {
                    b.HasOne("VetClinic_backend.Models.Animal", "Animal")
                        .WithMany("Visits")
                        .HasForeignKey("AnimalId");

                    b.HasOne("VetClinic_backend.Models.User", "Customer")
                        .WithMany("CustomerVisits")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetClinic_backend.Models.User", "Employee")
                        .WithMany("EmployeeVisits")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetClinic_backend.Models.VisitDetails", "VisitDetails")
                        .WithOne("Visit")
                        .HasForeignKey("VetClinic_backend.Models.Visit", "VisitDetailsId");

                    b.Navigation("Animal");

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("VisitDetails");
                });

            modelBuilder.Entity("VetClinic_backend.Models.Animal", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("VetClinic_backend.Models.User", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("CustomerVisits");

                    b.Navigation("EmployeeVisits");
                });

            modelBuilder.Entity("VetClinic_backend.Models.VisitDetails", b =>
                {
                    b.Navigation("Visit")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
