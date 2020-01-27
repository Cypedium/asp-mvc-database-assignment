using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_mvc_database_assignment.Models.Repo;
using asp_mvc_database_assignment.Models.ViewModels;

namespace asp_mvc_database_assignment.Models.Services
{
    public class AssignmentService : IAssignmentService
    {
        IAssignmentRepo _assignmentRepo;
        public AssignmentService(IAssignmentRepo assignmentRepo)
        {
            _assignmentRepo = assignmentRepo;
        }
        public List<Course> All()
        {
            return _assignmentRepo.All;
        }

        public Course Create(AssignmentViewModel assignment)
        {
            Course new_Assignment = new Course()
            {
                Title = assignment.Title,
                Description = assignment.Description
            };
            return _assignmentRepo.Create(new_Assignment); 
        }

        public bool Delete(int id)
        {
            
        }

        public Course Read(int id)
        {
           
        }

        public Course Update(Course assignment)
        {
            
        }
    }
}
