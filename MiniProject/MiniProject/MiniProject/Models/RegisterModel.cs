using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace MiniProject.Models
{
    public class RegisterModel
    {
        [Key]

        [Required(ErrorMessage = "Please enter Login name.")]
        [DisplayName("Login name")]
        [DataType(DataType.Text)]
        [MaxLength(100, ErrorMessage = "The Login name cannot be longer than 100 characters.")]
        public string LoginName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Password cannot be empty.")]
        [DisplayName("Password")]
        [MaxLength(100, ErrorMessage = "The Password cannot be longer than 100 characters.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Password confirmation")]
        [MaxLength(100, ErrorMessage = "The Password cannot be longer than 100 characters.")]
        [Compare("Password", ErrorMessage = "The entered passwords do not match.")]
        [StringLength(50, ErrorMessage = "Please Enter Confirm password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "The full name cannot be empty.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The email id cannot be empty.")]
        [DisplayName("Email id")] 
        public string EmailId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "The city field cannot be empty.")]
        [DisplayName("City")] 
        public string City { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "The phone number cannot be empty.")]
        [DisplayName("Phone Number")]
        public long Phone { get; set; }



    }
}