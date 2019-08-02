﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using studentapp.Model;

namespace studentapp.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20190730120206_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("studentapp.Model.Course", b =>
                {
                    b.Property<int>("CrseCode")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CrsCredits");

                    b.Property<string>("CrsDescription")
                        .IsRequired();

                    b.Property<string>("CrseTitle")
                        .IsRequired();

                    b.HasKey("CrseCode");

                    b.ToTable("tblcourses");
                });

            modelBuilder.Entity("studentapp.Model.Lecturer", b =>
                {
                    b.Property<int>("LecID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LecFname")
                        .IsRequired();

                    b.Property<string>("LecLname")
                        .IsRequired();

                    b.Property<string>("Lecemail")
                        .IsRequired();

                    b.Property<string>("Lecgender")
                        .IsRequired();

                    b.Property<string>("Lectitle");

                    b.Property<int>("lecphone");

                    b.HasKey("LecID");

                    b.ToTable("tbllecturers");
                });

            modelBuilder.Entity("studentapp.Model.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB");

                    b.Property<string>("Fname")
                        .IsRequired();

                    b.Property<string>("Lname")
                        .IsRequired();

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("gender")
                        .IsRequired();

                    b.Property<int>("phone");

                    b.HasKey("ID");

                    b.ToTable("tblstudents");
                });
#pragma warning restore 612, 618
        }
    }
}
