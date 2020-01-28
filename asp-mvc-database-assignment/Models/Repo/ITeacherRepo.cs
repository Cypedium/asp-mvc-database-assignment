using asp_mvc_database_assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public interface ITeacherRepo
    {
        Teacher Create(Teacher teacher);
        Teacher Find(int id);
        Teacher Update(Teacher teacher);
        bool Remove(Teacher teacher);
        List<Teacher> All();
    }
}
