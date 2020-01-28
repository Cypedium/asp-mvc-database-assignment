using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public class CourseRepo : ICourseRepo
    {
        HandleStudentsDbContext _handleStudentsDbContext;
        public CourseRepo(HandleStudentsDbContext handleStudentsDbContext)
        {
            _handleStudentsDbContext = handleStudentsDbContext;
        }
        public List<Course> All()
        {
            return _handleStudentsDbContext.Courses.ToList();
        }

        public Course Create(Course course)
        {
            _handleStudentsDbContext.Courses.Add(course);
                        
            _handleStudentsDbContext.SaveChanges();
            
            return course;
        }

        public bool Remove(Course course)
        {
            var result = _handleStudentsDbContext.Courses.Remove(course);
          
            _handleStudentsDbContext.SaveChanges();
            
            return true;
        }

        public Course Find(int id)
        {
            return _handleStudentsDbContext.Courses.SingleOrDefault(course => course.Id == id);
        }

        public Course Update(Course course)
        {
            Course newCourse = Find(course.Id);

            newCourse.Title = course.Title;
            newCourse.Description = course.Description;

            _handleStudentsDbContext.SaveChanges();

            return newCourse;
        }
    }

}
