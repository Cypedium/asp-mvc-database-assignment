using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public interface IAssignmentRepo
    {
        Course Create(Course assignment);
        Course Read(int id);
        Course Update(Course assignment);
        bool Delete(Course assignment);

        List<Course> All { get; }
    }
}
