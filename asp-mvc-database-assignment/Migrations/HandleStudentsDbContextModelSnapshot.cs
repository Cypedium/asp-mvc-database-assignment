﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using asp_mvc_database_assignment.Models;

namespace asp_mvc_database_assignment.Migrations
{
    [DbContext(typeof(HandleStudentsDbContext))]
    partial class HandleStudentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("asp_mvc_database_assignment.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(254)")
                        .HasMaxLength(254);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(63)")
                        .HasMaxLength(63);

                    b.HasKey("Id");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("asp_mvc_database_assignment.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(63)")
                        .HasMaxLength(63);

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("asp_mvc_database_assignment.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("MyGrade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("asp_mvc_database_assignment.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("E_mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(63)")
                        .HasMaxLength(63);

                    b.Property<string>("F_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(31)")
                        .HasMaxLength(31);

                    b.Property<string>("L_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(31)")
                        .HasMaxLength(31);

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("asp_mvc_database_assignment.Models.Student_Course_Map", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Student_Course_Map");
                });

            modelBuilder.Entity("asp_mvc_database_assignment.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("E_mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(63)")
                        .HasMaxLength(63);

                    b.Property<string>("F_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(31)")
                        .HasMaxLength(31);

                    b.Property<string>("L_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(31)")
                        .HasMaxLength(31);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(63)")
                        .HasMaxLength(63);

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("asp_mvc_database_assignment.Models.Course", b =>
                {
                    b.HasOne("asp_mvc_database_assignment.Models.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("asp_mvc_database_assignment.Models.Grade", b =>
                {
                    b.HasOne("asp_mvc_database_assignment.Models.Assignment", "Assignment")
                        .WithMany("Grades")
                        .HasForeignKey("AssignmentId");

                    b.HasOne("asp_mvc_database_assignment.Models.Course", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId");

                    b.HasOne("asp_mvc_database_assignment.Models.Student", null)
                        .WithMany("Grades")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("asp_mvc_database_assignment.Models.Student_Course_Map", b =>
                {
                    b.HasOne("asp_mvc_database_assignment.Models.Course", "Course")
                        .WithMany("Student_Course_Maps")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asp_mvc_database_assignment.Models.Student", "Student")
                        .WithMany("Student_Course_Maps")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
