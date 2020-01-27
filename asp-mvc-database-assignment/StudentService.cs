using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment
{  
    public class StudentService : IStudentService
    {
        readonly HandleStudentsDbContext _handleStudentsDbContext;
        public StudentService(HandleStudentsDbContext handleStudentsDbContext)
        {
            _handleStudentsDbContext = handleStudentsDbContext;
        }
    }    
}
