using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace Antique_Shop.Models
{
    public class BorrowedAuctionRepositorySQL : IBorrowedAuctionRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BorrowedAuctionRepositorySQL(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }

        public BorrowedAuction Add(BorrowedAuction auction)
        {
            dbContext.BorrowedAuctions.Add(auction);
            dbContext.SaveChanges();
            return auction;
        }

        public BorrowedAuction Delete(int id)
        {
            BorrowedAuction auction = dbContext.BorrowedAuctions.Find(id);
            if (auction != null)
            {
                dbContext.Remove(auction);
                dbContext.SaveChanges();
            }
            return auction;
        }

        public IEnumerable<BorrowedAuction> GetAllAuctions()
        {
            return dbContext.BorrowedAuctions;
        }


    }
}
