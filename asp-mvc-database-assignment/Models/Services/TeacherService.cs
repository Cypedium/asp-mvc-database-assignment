using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_mvc_database_assignment.Models.Repo;
using asp_mvc_database_assignment.Models.ViewModels;

namespace asp_mvc_database_assignment.Models.Services
{
    public class TeacherService : ITeacherService
    {
        ITeacherRepo _teacherRepo;

        public TeacherService(ITeacherRepo teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }
        public List<Teacher> All()
        {
            return _teacherRepo.All();
        }

        public Teacher Create(TeacherViewModel teacher)
        {
            Teacher new_Teacher = new Teacher()
            {
                F_Name = teacher.F_Name,
                L_Name = teacher.L_Name,
                Title = teacher.Title,
                E_mail = teacher.E_mail
            };

            return _teacherRepo.Create(new_Teacher);
        }

        public bool Remove(int id)
        {
            Teacher teacher = Find(id);

            if (teacher == null)
            {
                return false;
            }

            return _teacherRepo.Remove(teacher);
        }

        public Teacher Find(int id)
        {
            return _teacherRepo.Find(id);
        }

        public Teacher Update(Teacher teacher)
        {
            return _teacherRepo.Update(teacher); 
        }
    }
}
