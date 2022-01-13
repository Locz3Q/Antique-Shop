using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class SoldAuction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Category? Category { get; set; }
        public float Price { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string SellerId { get; set; }
        public int lendPeriod { get; set; } //in days
        public string Author { get; set; }
        public string ISBN { get; set; }
        public Condition? Condition { get; set; }
        public string BuyerId { get; set; }
      //  [ForeignKey("BuyerId")]
     //   public virtual Account BuyerAccount { get; set; }
    }
}
