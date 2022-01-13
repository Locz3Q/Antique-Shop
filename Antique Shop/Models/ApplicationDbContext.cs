using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<SoldAuction> SoldAuctions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Auction>().ToTable("Auctions");
            // .HasOne(auc => auc.SellerAccount)
            //  .WithMany(acc => acc.Auctions)
            //  .HasForeignKey(auc => auc.SellerId) ;

            modelBuilder.Entity<SoldAuction>().ToTable("SoldAuctions");
     //   .HasOne(auc => auc.BuyerAccount)
    //    .WithMany(acc => acc.SoldAuctions)
     //   .HasForeignKey(auc => auc.BuyerId);
        }
    }
}
