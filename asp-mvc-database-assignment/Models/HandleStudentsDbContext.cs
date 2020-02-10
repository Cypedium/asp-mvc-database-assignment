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
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            //***Init for Assignment Course Map as class Grade jointable**Many two many******
            modelBuilder.Entity<Grade>()
                .HasKey(assignment_Course_Map => new { assignment_Course_Map.AssignmentId, assignment_Course_Map.CourseId });

            modelBuilder.Entity<Grade>()
                .HasOne(ac => ac.Assignment)
                .WithMany(a => a.Grades)
                .HasForeignKey(ac => ac.AssignmentId);

            modelBuilder.Entity<Grade>()
                .HasOne(ac => ac.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(ac => ac.CourseId);

            //***Init for Student and Grade one to many***************************************
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Grades)
                .WithOne(g => g.Student)
                .HasForeignKey(g => g.StudentId);


            //***Init for Teacher and Courses one to many*************************************
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Student_Course_Maps)
                .WithOne(c => c.Teacher)
                .HasForeignKey(t => t.TeacherId);
                
            //********************************************************************************
        }
    }
}
