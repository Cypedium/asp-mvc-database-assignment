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
            return _handleStudentsDbContext.Assignments.ToList();
        }

        public Assignment Create(Assignment course)
        {
            _handleStudentsDbContext.Assignments.Add(course);
                        
            _handleStudentsDbContext.SaveChanges();
            
            return course;
        }

        public bool Remove(Assignment course)
        {
            var result = _handleStudentsDbContext.Assignments.Remove(course);
          
            _handleStudentsDbContext.SaveChanges();
            
            return true;
        }

        public Assignment Find(int id)
        {
            return _handleStudentsDbContext.Assignments.SingleOrDefault(course => course.Id == id);
        }

        public Assignment Update(Assignment course)
        {
            Assignment newCourse = Find(course.Id);

            newCourse.Title = course.Title;
            newCourse.Description = course.Description;

            _handleStudentsDbContext.SaveChanges();

            return newCourse;
        }
    }

}
