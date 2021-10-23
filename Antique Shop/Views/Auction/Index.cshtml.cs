using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antique_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Antique_Shop.Views.AuctionList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public IndexModel(ApplicationDbContext db)
        {
            database = db;
        }

        public IEnumerable<Auction> Auctions { get; set; }
        public async Task OnGet()
        {
            Auctions = await database.Auction.ToListAsync();
        }
    }
}
