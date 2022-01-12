using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class SoldAuction :  Auction
    {
  
        public string BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual Account BuyerAccount { get; set; }
    }
}
