using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public interface IAuctionRepository
    {
        Auction GetAuction(int id);
        IEnumerable<Auction> GetAllAuctions();
        Auction Add(Auction auction);
        Auction Update(Auction auction);
        Auction Delete(int id);

    }
}
