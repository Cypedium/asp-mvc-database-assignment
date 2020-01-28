using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public class StudentRepo : IStudentRepo
    {
        HandleStudentsDbContext _handleStudentsDbContext;
        public StudentRepo(HandleStudentsDbContext handleStudentsDbContext)
        {
            _handleStudentsDbContext = handleStudentsDbContext;
        }

        public List<Student> All()
        {
            return _handleStudentsDbContext.Students.ToList();
        }
        
        public Student Create(Student student)
        {
            _handleStudentsDbContext.Students.Add(student);

            _handleStudentsDbContext.SaveChanges();
            
            return student;
        }

        public bool Remove(Student student)
        {
            var result = _handleStudentsDbContext.Students.Remove(student);

            _handleStudentsDbContext.SaveChanges();
            
            return true;
        }

        public Student Find(int id)
        {
            return _handleStudentsDbContext.Students.SingleOrDefault(student => student.Id == id);
        }

        public Student Update(Student student)
        {
            Student newStudent = Find(student.Id);

            newStudent.F_Name = student.F_Name;
            newStudent.L_Name = student.L_Name;
            newStudent.E_mail = student.E_mail;

            _handleStudentsDbContext.SaveChanges();

            return newStudent;
        }
    }
}
