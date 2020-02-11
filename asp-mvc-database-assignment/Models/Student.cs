﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(31, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string F_Name { get; set; }

        [Required]
        [StringLength(31, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string L_Name { get; set; }

        [Required]
        [StringLength(63, MinimumLength = 6)]
        [Display(Name = "E-mail")]
        public string E_mail { get; set; }

        public List<Student_Course_Map> Student_Course_Maps { get; set; } //init for database many to many Course to Student

        public List<Grade> Grades { get; set; } //init for database one to many Student to Grade
    }
}
