using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public interface IBorrowedAuctionRepository
    {

            // SoldAuction GetAuction(int id);
        IEnumerable<BorrowedAuction> GetAllAuctions();
        BorrowedAuction Add(BorrowedAuction auction);
        //  SoldAuction Update(SoldAuction auction);
        BorrowedAuction Delete(int id);
    }
}
