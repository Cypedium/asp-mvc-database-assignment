using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength (63, MinimumLength = 1)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(254, MinimumLength = 10)]
        public string Description { get; set; }

        public List<Grade> Grades { get; set; }
    }
}
