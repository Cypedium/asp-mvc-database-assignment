using asp_mvc_database_assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public class AssignmentRepo : IAssignmentRepo
    {
        HandleStudentsDbContext _handleStudentsDbContext;
        public AssignmentRepo(HandleStudentsDbContext handleStudentsDbContext)
        {
            _handleStudentsDbContext = handleStudentsDbContext;
        }
        public List<Course> All => _handleStudentsDbContext.Assignments.ToList();

        public Course Create(Course assignment)
        {
            _handleStudentsDbContext.Assignments.Add(assignment);
            _handleStudentsDbContext.SaveChanges();
            return assignment;
        }

        public bool Delete(Course assignment)
        {
            var result = _handleStudentsDbContext.Assignments.Remove(assignment);

            _handleStudentsDbContext.SaveChanges();
            return true;
             
        }

        public Course Read(int id)
        {
            return _handleStudentsDbContext.Assignments.SingleOrDefault(assignment => assignment.Id == id); 
        }

        public Course Update(Course assignment)
        {
            Course database = Read(assignment.Id);

            database.Title = assignment.Title;
            database.Description = assignment.Description;

            _handleStudentsDbContext.SaveChanges();

            return database;
        }
    }
}
