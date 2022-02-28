using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SohanSirZindabad.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string CategoryName { get; set; }
    }
}