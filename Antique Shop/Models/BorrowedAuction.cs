using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class BorrowedAuction
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Category? Category { get; set; }
        public float Price { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string SellerId { get; set; }
        public DateTime DeadlineForBorrow { get; set; } //in days
        public string Author { get; set; }
        public string ISBN { get; set; }
        public Condition? Condition { get; set; }
        public string BorrowerId { get; set; }
    }
}
