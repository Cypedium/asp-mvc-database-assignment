using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    interface IStudentRepo
    {
        Student Create(Student student);
        Student Read(int studentId);
        Student Update(Student studentId);
        bool Delete(int id);

        List<Student> All();
    }
}
