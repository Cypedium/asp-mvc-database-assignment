using asp_mvc_database_assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    interface ITeacherRepo
    {
        Teacher Create(Teacher teacher);
        Teacher Read(int id);
        Teacher Update(Teacher teacher);
        bool Delete(Teacher teacher);

        List<Teacher> All();
    }
}
