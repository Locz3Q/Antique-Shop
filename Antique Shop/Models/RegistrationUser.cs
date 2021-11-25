using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Antique_Shop.Models
{
    public class RegistrationUser
    {
        [Key]
        public int id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login is required!")]
        public string login { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        public string password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        public string email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required!")]
        public string firstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required!")]
        public string lastName { get; set; }
        public DateTime accountCreateDate { get; set; }
    }
}
