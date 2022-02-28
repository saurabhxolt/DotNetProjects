using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductProject.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { set; get; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Category Name")]
        [StringLength(50, ErrorMessage = "The {0} value can`t be greater than {1} characters")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}