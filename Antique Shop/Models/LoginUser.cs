using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class LoginUser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login is required!")]
        public string login { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        public string password { get; set; }

    }
}
