using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antique_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Antique_Shop.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Antique_Shop.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionRepository auctionRepository;
        private readonly ISoldAuctionRepository soldAuctionRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;



        public string GetCurrentUserId()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }
        public AuctionController(IAuctionRepository auctionRepository, ISoldAuctionRepository soldAuctionRepository, IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this.auctionRepository = auctionRepository;
            this.soldAuctionRepository = soldAuctionRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AuctionViewModel auctionViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (auctionViewModel.Image != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + auctionViewModel.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    auctionViewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Auction auction = new Auction
                {
                    Name = auctionViewModel.Name,
                    ReleaseDate = auctionViewModel.ReleaseDate,
                    Category = auctionViewModel.Category,
                    Price = auctionViewModel.Price,
                    ImagePath = fileName,
                    Description = auctionViewModel.Description
                };

                auctionRepository.Add(auction);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
           [HttpPost]
           public IActionResult Buy(int id)
           {
            var auction = auctionRepository.GetAuction(id);
            string buyerId = this.GetCurrentUserId();
            if(buyerId == auction.SellerId)
            {
                return View();
            }
            else 
            { 
            SoldAuction soldAuction = new SoldAuction{
           // Id = auction.Id,
            Name = auction.Name,
            ReleaseDate = auction.ReleaseDate,
            Category = auction.Category,
            Price = auction.Price,
            ImagePath = auction.ImagePath,
            Description = auction.Description,
            SellerId = auction.SellerId,
            Author = auction.Author,
            ISBN = auction.ISBN,
            Condition = auction.Condition,
            BuyerId = buyerId
            };
            soldAuctionRepository.Add(soldAuction);
            auctionRepository.Delete(id);
            return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ViewResult CreateLend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLend(AuctionLendViewModel auctionLendViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (auctionLendViewModel.Image != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + auctionLendViewModel.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    auctionLendViewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Auction auction = new Auction
                {
                    Name = auctionLendViewModel.Name,
                    ReleaseDate = auctionLendViewModel.ReleaseDate,
                    Category = auctionLendViewModel.Category,
                    Price = auctionLendViewModel.Price,
                    ImagePath = fileName,
                    Description = auctionLendViewModel.Description,
                    Author = auctionLendViewModel.Author,
                    ISBN = auctionLendViewModel.ISBN,
                    Condition = auctionLendViewModel.Condition,
                    lendPeriod = auctionLendViewModel.lendPeriod
                };

                auctionRepository.Add(auction);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
