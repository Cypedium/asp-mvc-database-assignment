using asp_mvc_database_assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment
{
    public class HandleStudentsDbContext: DbContext 
    {
        public HandleStudentsDbContext(DbContextOptions<HandleStudentsDbContext> options) : base(options)
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assignment> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}
