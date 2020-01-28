using asp_mvc_database_assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public class HandleStudentsDbContext: DbContext 
    {
        public HandleStudentsDbContext(DbContextOptions<HandleStudentsDbContext> options) : base(options)
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_Course_Map>()
                .HasKey(student_Course_Map => new { student_Course_Map.StudentId, student_Course_Map.CourseId }); //t is only a variable
            modelBuilder.Entity<Student_Course_Map>()
                .HasOne(sc => sc.Student) //sc=studentcourse
                .WithMany(s => s.Student_Course_Maps)
                .HasForeignKey(sc => sc.Id);

            modelBuilder.Entity<Student_Course_Map>()
                .HasOne(sc => sc.Course) //sc=studentcourse
                .WithMany(s => s.Student_Course_Maps)
                .HasForeignKey(sc => sc.Id);
        }
    }
}
