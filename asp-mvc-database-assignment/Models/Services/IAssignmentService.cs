using asp_mvc_database_assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Services
{
    interface IAssignmentService
    {
        Course Create(AssignmentViewModel assignment);
        Course Read(int id);
        Course Update(Course assignment);
        bool Delete(int id);

        List<Course> All();
    }
}
