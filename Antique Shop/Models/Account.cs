using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Antique_Shop.Models
{
    public class Account : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int ApartmentNumber { get; set; }
        public int Postcode { get; set; }
        public string City { get; set; }
        public float Saldo { get; set; }
        public DateTime AccountCreateDate { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
        public virtual ICollection<SoldAuction> SoldAuctions { get; set; }

    }
}
