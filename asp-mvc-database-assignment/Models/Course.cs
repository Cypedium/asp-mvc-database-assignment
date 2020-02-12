using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(63, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 10)]
        public string Description { get; set; }
        
        public List<Student_Course_Map> Student_Course_Maps { get; set; } //many to many student to course
        
        public List<Assignment> Assignments { get; set; } //one to many Course to Assignment
       
        public Teacher Teacher { get; set; } //one to many teacher to courses
    }
}
