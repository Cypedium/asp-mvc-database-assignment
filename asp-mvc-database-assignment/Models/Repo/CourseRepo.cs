using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public class CourseRepo : IAssignmentRepo
    {
        HandleStudentsDbContext _handleStudentsDbContext;
        public CourseRepo(HandleStudentsDbContext handleStudentsDbContext)
        {
            _handleStudentsDbContext = handleStudentsDbContext;
        }
        public List<Course> All => _handleStudentsDbContext.Assignments.ToList();

        public Course Create(Course course)
        {
            _handleStudentsDbContext.Assignments.Add(course);
            _handleStudentsDbContext.SaveChanges();
            return course;
        }

        public bool Delete(Course course)
        {
            var result = _handleStudentsDbContext.Assignments.Remove(course);

            _handleStudentsDbContext.SaveChanges();
            return true;

        }

        public Course Read(int id)
        {
            return _handleStudentsDbContext.Assignments.SingleOrDefault(course => course.Id == id);
        }

        public Course Update(Course course)
        {
            Course database = Read(course.Id);

            database.Title = course.Title;
            database.Description = course.Description;

            _handleStudentsDbContext.SaveChanges();

            return database;
        }
    }

}
