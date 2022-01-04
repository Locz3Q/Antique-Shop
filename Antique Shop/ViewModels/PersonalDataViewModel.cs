using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.ViewModels
{
    public class PersonalDataViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required!")]
        [MinLength(3, ErrorMessage = "First Name can not be shorter than 5!")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required!")]
        [MinLength(3, ErrorMessage = "Last Name can not be shorter than 3!")]
        public string LastName { get; set; }
        [MinLength(3, ErrorMessage = "Street can not be shorter than 3!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street is required!")]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Apartment Number is required!")]
        public int ApartmentNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Postcode is required!")]
        public int Postcode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required!")]
        [MinLength(3, ErrorMessage = "City can not be shorter than 3!")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required!")]
        public string PhoneNumber { get; set; }
    }
}
