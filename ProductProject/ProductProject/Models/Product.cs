using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductProject.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Product Name")]
        [StringLength(50, ErrorMessage = "The {0} value can`t be greater than {1} characters")]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please Enter Rate")]
        [Display(Name = "Rate")]
        public decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(200, ErrorMessage = "The {0} value can`t be greater than {1} characters")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Please select Category Name")]
        public int CategoryId { get; set; }
    }
}