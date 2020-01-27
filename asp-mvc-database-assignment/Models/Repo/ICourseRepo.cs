using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    interface ICourseRepo
    {
        Course Create(Course course);
        Course Read(int id);
        Course Update(Course course);
        bool Delete(Course assignment);

        List<Course> All();
    }
}
