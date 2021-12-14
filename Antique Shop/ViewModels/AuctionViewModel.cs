using Antique_Shop.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.ViewModels
{
    public class AuctionViewModel
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Category? Category { get; set; }
        public float Price { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
    }
}
