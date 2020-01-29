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
            //***Init for Student Course Map jointable****************************************
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
            //********************************************************************************


            //***Init for Assignment Course Map jointable*************************************
            modelBuilder.Entity<Grade>()
                .HasKey(assignment_Course_Map => new { assignment_Course_Map.AssignmnetId, assignment_Course_Map.CourseId });

            modelBuilder.Entity<Grade>()
                .HasOne(ac => ac.Assignment)
                .WithMany(a => a.Assignmnet_Course_Maps)
                .HasForeignKey(ac => ac.Id);

            modelBuilder.Entity<Grade>()
                .HasOne(grade => grade.Course)
                .WithMany(c => c.Assignmnet_Course_Maps)
                .HasForeignKey(grade => grade.Id);
            //********************************************************************************

            //***Init for Student and Grade one to many***************************************
            modelBuilder.Entity<Student>()
                .HasOne<Grade>()
                .WithMany()
                .HasForeignKey(student => student.Id); 
        }
    }
}
