﻿// <auto-generated />
using System;
using MainApp.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MainApp.DataModels.Migrations
{
    [DbContext(typeof(SystemContext))]
    partial class SystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeDepartment", b =>
                {
                    b.Property<Guid>("Employee")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Department")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Employee", "Department");

                    b.HasIndex("Department");

                    b.ToTable("EmployeeDepartment", (string)null);
                });

            modelBuilder.Entity("MainApp.DataModels.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("MainApp.DataModels.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .IsUnicode(true)
                        .HasColumnType("char(11)");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("MainApp.DataModels.Client", b =>
                {
                    b.HasBaseType("MainApp.DataModels.Person");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("MainApp.DataModels.Employee", b =>
                {
                    b.HasBaseType("MainApp.DataModels.Person");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("EmployeeDepartment", b =>
                {
                    b.HasOne("MainApp.DataModels.Department", null)
                        .WithMany()
                        .HasForeignKey("Department")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MainApp.DataModels.Employee", null)
                        .WithMany()
                        .HasForeignKey("Employee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MainApp.DataModels.Client", b =>
                {
                    b.HasOne("MainApp.DataModels.Person", null)
                        .WithOne()
                        .HasForeignKey("MainApp.DataModels.Client", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MainApp.DataModels.Employee", b =>
                {
                    b.HasOne("MainApp.DataModels.Person", null)
                        .WithOne()
                        .HasForeignKey("MainApp.DataModels.Employee", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
