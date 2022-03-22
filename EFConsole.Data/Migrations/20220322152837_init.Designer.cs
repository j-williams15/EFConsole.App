﻿// <auto-generated />
using System;
using EmployeeApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFConsole.Data.Migrations
{
    [DbContext(typeof(AssignmentContext))]
    [Migration("20220322152837_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeApp.Domain.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7976e249-788d-4948-b879-9c42b623ba80"),
                            EmployeeId = new Guid("be2940db-ba26-457d-9759-acdeaf2e1a90"),
                            EndDate = new DateTime(2022, 3, 22, 10, 28, 37, 586, DateTimeKind.Local).AddTicks(3197),
                            Name = "UnnamedDpt",
                            StartDate = new DateTime(2022, 3, 22, 10, 28, 37, 586, DateTimeKind.Local).AddTicks(3236)
                        });
                });

            modelBuilder.Entity("EmployeeApp.Domain.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a4e0da59-836b-4432-aaa9-96192a9cf066"),
                            FirstName = "Assinment.FirstName",
                            LastName = "Assinment.LastName"
                        });
                });

            modelBuilder.Entity("EmployeeApp.Domain.Assignment", b =>
                {
                    b.HasOne("EmployeeApp.Domain.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
