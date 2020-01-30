using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public interface ITeacherService
    {
        Teacher Create(TeacherViewModel course);
        Teacher Find(int id);
        Teacher Update(Teacher teacher);
        bool Remove(int id);
        List<Teacher> All();
    }
}
