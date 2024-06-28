﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RaviSirTaskJune20.Models;

#nullable disable

namespace RaviSirTaskJune20.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240624072401_First1")]
    partial class First1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RaviSirTask0506.Models.Classes", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("RaviSirTaskJune20.Models.Sections", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"));

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionId");

                    b.HasIndex("ClassId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("RaviSirTaskJune20.Models.Students", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SectionId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("RaviSirTaskJune20.Models.Subjects", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.HasIndex("ClassId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("RaviSirTaskJune20.Models.Teachers", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SectionId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("RaviSirTaskJune20.Models.Sections", b =>
                {
                    b.HasOne("RaviSirTask0506.Models.Classes", "Class")
                        .WithMany("Sections")
                        .HasForeignKey("ClassId");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("RaviSirTaskJune20.Models.Students", b =>
                {
                    b.HasOne("RaviSirTask0506.Models.Classes", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("RaviSirTaskJune20.Models.Sections", "Section")
                        .WithMany("Students")
                        .HasForeignKey("SectionId");

                    b.Navigation("Class");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("RaviSirTaskJune20.Models.Subjects", b =>
                {
                    b.HasOne("RaviSirTask0506.Models.Classes", "Class")
                        .WithMany("Subjects")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("RaviSirTaskJune20.Models.Teachers", b =>
                {
                    b.HasOne("RaviSirTask0506.Models.Classes", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("RaviSirTaskJune20.Models.Sections", "Section")
                        .WithMany("Teachers")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("RaviSirTask0506.Models.Classes", b =>
                {
                    b.Navigation("Sections");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("RaviSirTaskJune20.Models.Sections", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
