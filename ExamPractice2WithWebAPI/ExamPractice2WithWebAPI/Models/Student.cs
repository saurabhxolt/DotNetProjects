using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamPractice2WithWebAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Marks Required")]
        [Range(1, 100, ErrorMessage = "The {0} must be between {1}&{2}")]
        public int JavaMarks { get; set; }
        [Required(ErrorMessage = "Marks Required")]
        [Range(1, 100, ErrorMessage = "The {0} must be between {1}&{2}")]
        public int DotNetMarks { get; set; }
    }
}