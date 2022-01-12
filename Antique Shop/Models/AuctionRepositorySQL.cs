using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class AuctionRepositorySQL : IAuctionRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

      

        public string GetCurrentUserId()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }


        public AuctionRepositorySQL(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Auction Add(Auction auction)
        {
            // var user = UserManager.FindById(User.Identity.GetUserId());
            // Account currentUser = dbContext.Users.FirstOrDefault(x => x.Id == currentUserId);
            auction.SellerId = this.GetCurrentUserId();
            dbContext.Auctions.Add(auction);
            dbContext.SaveChanges();
            return auction;
        }

        public Auction Delete(int id)
        {
            Auction auction = dbContext.Auctions.Find(id);
            if (auction != null)
            {
                dbContext.Remove(auction);
                dbContext.SaveChanges();
            }
            return auction;
        }

        public IEnumerable<Auction> GetAllAuctions()
        {
            return dbContext.Auctions;
        }

        public Auction GetAuction(int id)
        {
            return dbContext.Auctions.Find(id);
        }

        public Auction Update(Auction auctionUpdate)
        {
            var auction = dbContext.Auctions.Attach(auctionUpdate);
            auction.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return auctionUpdate;
        }
    }
}
