using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public interface IStudentRepo
    {
        Student Create(Student student);
        Student Find(int id);
        Student Update(Student student);
        bool Remove(Student student);
        List<Student> All();
    }
}
