using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_mvc_database_assignment.Models.Repo;
using asp_mvc_database_assignment.Models.ViewModels;

namespace asp_mvc_database_assignment.Models.Services
{
    public class StudentService : IStudentService
    {
        IStudentRepo _studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public List<Student> All()
        {
            return _studentRepo.All();  
        }

        public Student Create(StudentViewModel student)
        {
            Student new_Student = new Student()
            {
                F_Name = student.F_Name,
                L_Name = student.L_Name,
                E_mail = student.E_mail
            };

            return _studentRepo.Create(new_Student);
        }

        public bool Remove(int id)
        {
            Student student = Find(id);
            
            if (student == null)
            {
                return false;
            }

            return _studentRepo.Remove(student);
        }

        public Student Find(int id)
        {
            return _studentRepo.Find(id); 
        }

        public Student Update(Student student)
        {
            return _studentRepo.Update(student);
        }
    }
}
