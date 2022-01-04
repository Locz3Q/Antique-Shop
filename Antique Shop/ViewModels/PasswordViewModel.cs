using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.ViewModels
{
    public class PasswordViewModel : IdentityUser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "New Password is required!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm New Password is required!")]
        [Compare("NewPassword", ErrorMessage = "Passwords are not the same!")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }
}

