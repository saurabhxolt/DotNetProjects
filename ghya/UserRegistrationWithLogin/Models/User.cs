using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserRegistrationWithLogin.Models
{
    public class User
    {
        public String LoginName { get; set; }
        public String Password { get; set; }
        public String ConPasssword { get; set; }
        public String FullName { get; set; }
        public String EmailId { get; set; }
        public String City { get; set; }
        public int Phone { get; set; }
    }
}
//Login name ______Password ______Confirm password ______Full Name______EmailId______City____ (Dropdown) Phone____




