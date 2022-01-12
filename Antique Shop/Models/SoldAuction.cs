using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class SoldAuction :  Auction
    {
        public SoldAuction (Auction auction, string BuyerId)
        {
            this.Id = auction.Id;
            this.Name = auction.Name;
            this.ReleaseDate = auction.ReleaseDate;
            this.Category = auction.Category;
            this.Price = auction.Price;
            this.ImagePath = auction.ImagePath;
            this.Description = auction.Description;
            this.SellerId = auction.SellerId;
            this.Author = auction.Author;
            this.Name = auction.Name;
            this.ISBN = auction.ISBN;
            this.Condition = auction.Condition;
            this.BuyerId = BuyerId;
    }
        public string BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual Account BuyerAccount { get; set; }
    }
}
