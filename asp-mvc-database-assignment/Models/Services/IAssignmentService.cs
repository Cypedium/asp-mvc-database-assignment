using asp_mvc_database_assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Services
{
    public interface IAssignmentService
    {
        Assignment Create(AssignmentViewModel assignment);
        Assignment Find(int id);
        Assignment Update(Assignment assignment);
        bool Remove(int id);
        List<Assignment> All();
    }
}
