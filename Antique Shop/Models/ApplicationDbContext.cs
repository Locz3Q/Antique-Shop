using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antique_Shop.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Auction> Auctions{ get; set; }
        // public DbSet<LoginUser> LoginUser { get; set; }

        /*     protected override void OnModelCreating(ModelBuilder modelBuilder)
             {
                 modelBuilder.Entity<Auction>()
            .ToTable("Auctions", t => t.ExcludeFromMigrations());
             }*/
    }
}
