using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MiniProject.Models
{
    public class LoginModel
    {

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
    }
}