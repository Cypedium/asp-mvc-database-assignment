using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public interface ICourseRepo
    {
        Assignment Create(Assignment course);
        Assignment Find(int id);
        Assignment Update(Assignment course);
        bool Remove(Assignment assignment);
        List<Assignment> All();
    }
}
