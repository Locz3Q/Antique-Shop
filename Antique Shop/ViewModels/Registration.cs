using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.ViewModel
{
    public class Registration
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login is required!")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required!")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required!")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street is required!")]
        public string Street { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Apartment Number is required!")]
        public int ApartmentNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Postcode is required!")]
        public int Postcode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required!")]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required!")]
        public string PhoneNumber { get; set; }
    }
}
