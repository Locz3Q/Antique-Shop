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

namespace Antique_Shop.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionRepository auctionRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public AuctionController(IAuctionRepository auctionRepository, IHostingEnvironment hostingEnvironment)
        {
            this.auctionRepository = auctionRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index()
        {
            var auction = auctionRepository.GetAllAuctions();
            return View(auction);
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
                if(auctionViewModel.Image != null)
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
                return RedirectToAction("index");
            }
            return View();
        }
        Auction createAuction()
        {

        }
    }
}
