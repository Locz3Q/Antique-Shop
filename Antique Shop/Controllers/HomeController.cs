using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Antique_Shop.Models;

namespace Antique_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuctionRepository auctionRepository;

        public HomeController(ILogger<HomeController> logger, IAuctionRepository auctionRepository)
        {
            _logger = logger;
            this.auctionRepository = auctionRepository;
        }

        public IActionResult Index()
        {
            var auction = auctionRepository.GetAllAuctions();

            // Dodane przez Roberta - mapa, w której klucze to nazwy kategorii, a wartości to wszystkie książki z tej kategorii w bazie
            Dictionary<Category, int> dictionary = new Dictionary<Category, int>();
            foreach(Category category in Enum.GetValues(typeof(Category)))
            {
                dictionary.Add(category, 0);
            }

            foreach (var a in auction)
            {
                if(dictionary.ContainsKey((Category)a.Category)) dictionary[(Category) a.Category]++;
            }
            

            return View(new Tuple<IEnumerable<Auction>, Dictionary<Category, int>>(auction,dictionary));
        }
        
        
        public IActionResult Details(int id)
        {
            var selectedAuction = auctionRepository.GetAuction(id);
            return View(selectedAuction);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
