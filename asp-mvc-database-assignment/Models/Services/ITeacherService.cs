using asp_mvc_database_assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Services
{
    interface ITeacherService
    {
        Teacher Create(TeacherViewModel course);
        Teacher Read(int id);
        Teacher Update(Teacher teacher);
        bool Delete(int id);

        List<Teacher> All();
    }
}
