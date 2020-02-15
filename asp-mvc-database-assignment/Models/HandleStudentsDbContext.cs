using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using asp_mvc_database_assignment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace asp_mvc_database_assignment.Models
{
    public class HandleStudentsDbContext: IdentityDbContext 
    {
        public HandleStudentsDbContext(DbContextOptions<HandleStudentsDbContext> options) : base(options)
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //trying to solve "The entity type 'IdentityUserLogin<string>' requires a primary key to be defined." when migrate
            //***Init for Student Course Map jointable****************************************
            modelBuilder.Entity<Student_Course_Map>()
                .HasKey(student_Course_Map => new { student_Course_Map.StudentId, student_Course_Map.CourseId }); //t is only a variable

            modelBuilder.Entity<Student_Course_Map>()
                .HasOne(sc => sc.Student) //sc=studentcourse
                .WithMany(s => s.Student_Course_Maps)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<Student_Course_Map>()
                .HasOne(sc => sc.Course) //sc=studentcourse
                .WithMany(c => c.Student_Course_Maps)
                .HasForeignKey(sc => sc.CourseId);            
        }
    }
}
