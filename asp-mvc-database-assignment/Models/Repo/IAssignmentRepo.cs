using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public interface IAssignmentRepo
    {
        Assignment Create(Assignment assignment);
        Assignment Find(int id);
        Assignment Update(Assignment assignment);
        bool Remove(Assignment assignment);
        List<Assignment> All();
    }
}
