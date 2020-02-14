using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public class RoleViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }
    }
}
