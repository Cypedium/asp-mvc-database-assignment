using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_mvc_database_assignment.Models.Repo;
using asp_mvc_database_assignment.Models.ViewModels;

namespace asp_mvc_database_assignment.Models.Services
{
    public class CourseService : ICourseService
    {
        ICourseRepo _courseRepo;

        public CourseService(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public List<Course> All()
        {
            return _courseRepo.All();
        }

        public Course Create(CourseViewModel course)
        {
            Course new_Course = new Course()
            {
                Description = course.Description,
                Title = course.Title
            };

            return _courseRepo.Create(new_Course);
        }

        public Course Find(int id)
        {
            return _courseRepo.Find(id);
        }

        public bool Remove(int id)
        {
            Course course = Find(id);

            if (course == null)
            {
                return false;
            }

            return _courseRepo.Remove(course);
        }

        public Course Update(Course course)
        {
            return _courseRepo.Update(course);
        }
    }
}
