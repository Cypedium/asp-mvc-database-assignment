using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public class Grade //This is a jointable between Assignmnet and Course and 1 to many Student to Grade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MyGrade { get; set; }

        //--Many to many---Course to Assignment------------
        [Required]
        public int AssignmentId { get; set; }

        [Required]
        public int CourseId { get; set; }
  
        public Assignment Assignment { get; set; }

        public Course Course { get; set; }

        //---One to many Grade to Student------------------      
        public Student Student { get; set; }
        public int StudentId { get; set; }
        //-------------------------------------------------
    }
}
