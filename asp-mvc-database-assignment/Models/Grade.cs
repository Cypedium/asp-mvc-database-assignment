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

        //--Many to many-------------------------
        [Required]
        public int AssignmnetId { get; set; }

        [Required]
        public int CourseId { get; set; }
  
        public Assignment Assignment { get; set; }

        public Course Course { get; set; }
        //---------------------------------------

        //--One to Many--------------------------
        //[Required]
        //public int StudentId {get; set;}

        //[Required]
        //public Student Student { get; set; }
        //---------------------------------------
    }
}
