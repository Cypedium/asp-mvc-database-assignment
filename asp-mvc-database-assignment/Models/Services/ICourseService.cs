using asp_mvc_database_assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Services
{
    public interface ICourseService
    {
        Course Create(CourseViewModel course);
        Course Read(int id);
        Course Update(Course course);
        bool Remove(int id);
        List<Course> All();
    }
}
