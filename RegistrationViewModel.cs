using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Assignment1.Models
{
    
        public class RegistrationViewModel
        {
            public int EmpNo { get; set; }

            [Required]
            [Display(Name = "FirstName: ")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "LastName: ")]
            public string LastName { get; set; }



            [Required]
            [EmailAddress]
            [StringLength(150)]
            [Display(Name = "Email Address: ")]
            public string Email { get; set; }
            [Required]
            [Display(Name = "City: ")]
            public string City { get; set; }
            [Required(ErrorMessage = "You must provide a phone number,Phone Number at least 10 digit")]
            [Display(Name = "ContactNo")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
            public string ContactNo { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [StringLength(150, MinimumLength = 6)]
            [Display(Name = "Password: ")]
            public string Password { get; set; }
        }
    }
