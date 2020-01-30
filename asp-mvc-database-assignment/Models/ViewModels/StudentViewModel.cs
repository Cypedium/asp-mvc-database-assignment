using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public class StudentViewModel
    {
        [Required]
        [StringLength(31, MinimumLength = 2)]
        public string F_Name { get; set; }

        [Required]
        [StringLength(31, MinimumLength = 2)]
        public string L_Name { get; set; }

        [Required]
        [StringLength(63, MinimumLength = 6)]
        public string E_mail { get; set; }
    }
}
