using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class SoldAuctionRepositorySQL : ISoldAuctionRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SoldAuctionRepositorySQL(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

    public string GetCurrentUserId()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }

        public SoldAuction Add(SoldAuction auction)
        {
            dbContext.Auctions.Add(auction);
            dbContext.SaveChanges();
            return auction;
        }

        public SoldAuction Delete(int id)
        {
            SoldAuction auction = dbContext.SoldAuctions.Find(id);
            if (auction != null)
            {
                dbContext.Remove(auction);
                dbContext.SaveChanges();
            }
            return auction;
        }

        public IEnumerable<SoldAuction> GetAllAuctions()
        {
            return dbContext.SoldAuctions;
        }


    }
}
