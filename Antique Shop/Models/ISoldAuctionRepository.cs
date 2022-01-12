using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public interface ISoldAuctionRepository
    {
       // SoldAuction GetAuction(int id);
        IEnumerable<SoldAuction> GetAllAuctions();
        SoldAuction Add(SoldAuction auction);
      //  SoldAuction Update(SoldAuction auction);
        SoldAuction Delete(int id);
    }
}
