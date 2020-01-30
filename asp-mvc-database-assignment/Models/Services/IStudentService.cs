using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public interface IStudentService
    {
        Student Create(StudentViewModel course);
        Student Find(int id);
        Student Update(Student student);
        bool Remove(int id);
        List<Student> All();
    }
}
