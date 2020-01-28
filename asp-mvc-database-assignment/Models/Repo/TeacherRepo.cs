using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public class TeacherRepo : ITeacherRepo
    {
        HandleStudentsDbContext _handleStudentsDbContext;

        public TeacherRepo(HandleStudentsDbContext handleStudentsDbContext)
        {
            _handleStudentsDbContext = handleStudentsDbContext;
        }
        public List<Teacher> All()
        {
            return _handleStudentsDbContext.Teachers.ToList();
        }

        public Teacher Create(Teacher teacher)
        {
            _handleStudentsDbContext.Teachers.Add(teacher);

            _handleStudentsDbContext.SaveChanges();

            return teacher;
        }

        public Teacher Find(int id)
        {
            return _handleStudentsDbContext.Teachers.SingleOrDefault(teacher => teacher.Id == id);
        }

        public bool Remove(Teacher teacher)
        {
           var result = _handleStudentsDbContext.Teachers.Remove(teacher);

            _handleStudentsDbContext.SaveChanges();

            return true;
        }

        public Teacher Update(Teacher teacher)
        {
            Teacher newTeacher = Find(teacher.Id);

            newTeacher.F_Name = teacher.F_Name;
            newTeacher.L_Name = teacher.L_Name;
            newTeacher.Title = teacher.Title;
            newTeacher.E_mail = teacher.E_mail;

            _handleStudentsDbContext.SaveChanges();
            
            return newTeacher;
        }
    }
}
