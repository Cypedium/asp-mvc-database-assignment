using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public class Student_Course_Map
    {
        [Key]
        public int Id { get; set; } //need this to be certan that the database could delete a row
        
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Student Student { get; set; } //uses to access list in Student class
        public Course Course { get; set; } //uses to access list in Course class
    }
}
