using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public interface ICourseRepo
    {
        Course Create(Course course);
        Course Find(int id);
        Course Update(Course course);
        bool Remove(Course course);
        List<Course> All();
    }
}
