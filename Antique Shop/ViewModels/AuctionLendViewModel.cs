using Antique_Shop.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.ViewModels
{
    public class AuctionLendViewModel
    {
        [Required]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public Category? Category { get; set; }
        [Required]
        public float Price { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        public string Description { get; set; }
        public string SellerId { get; set; }
        [Required]
        public int lendPeriod { get; set; } //in days
        [Required]
        public string Author { get; set; }
        public string ISBN { get; set; }
        [Required]
        public Condition? Condition { get; set; }
    }
}
