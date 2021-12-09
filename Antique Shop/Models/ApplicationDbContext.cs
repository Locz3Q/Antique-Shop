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

        //public DbSet<Auction> Auctions{ get; set; }
        public DbSet<Account> Accounts { get; set; }
        // public DbSet<LoginUser> LoginUser { get; set; }

             protected override void OnModelCreating(ModelBuilder modelBuilder)
             {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<Account>(b =>
            {
                b.HasKey(u => u.Id);
                b.ToTable("AspNetUsers");
        }) ;*/
          //  modelBuilder.Entity<Account>().HasKey(u => u.id);
           // modelBuilder.ToTable("asdsad");
            //  modelBuilder.Entity<Account>()
            //     .ToTable("Accounts", t => t.ExcludeFromMigrations());
        }
    }
}
