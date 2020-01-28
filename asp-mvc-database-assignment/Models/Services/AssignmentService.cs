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

        public List<Assignment> All()
        {
            return _assignmentRepo.All();
        }

        public Assignment Create(AssignmentViewModel assignment)
        {
            Assignment new_Assignment = new Assignment()
            {
                Title = assignment.Title,
                Description = assignment.Description
            };

            return _assignmentRepo.Create(new_Assignment); 
        }

        public bool Remove(int id)
        {
            Assignment assignment = Find(id);

            if (assignment == null)
            {
                return false;
            }

            return _assignmentRepo.Remove(assignment);
        }

        public Assignment Find(int id)
        {
            return _assignmentRepo.Find(id);
        }

        public Assignment Update(Assignment assignment)
        {
            return _assignmentRepo.Update(assignment);  
        }
    }
}
