using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antique_Shop.Models;
using Antique_Shop.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Antique_Shop.Controllers
{
    public class MyProfileController : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly IAccountRepository accountRepository;
        public MyProfileController(UserManager<Account> userManager, IAccountRepository accountRepository)
        {
            this.userManager = userManager;
            this.accountRepository = accountRepository;
        }
        public async Task <IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }

        [HttpGet]
        public async Task <IActionResult> Edit()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            Registration _user = new Registration
            {
                Login = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Street = user.Street,
                ApartmentNumber = user.ApartmentNumber,
                Postcode = user.Postcode,
                City = user.City,
                PhoneNumber = user.PhoneNumber
            };

            return View(_user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Registration model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                user.UserName = model.Login;
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Street = model.Street;
                user.ApartmentNumber = model.ApartmentNumber;
                user.Postcode = model.Postcode;
                user.City = model.City;
                user.PhoneNumber = model.PhoneNumber;

                Account updatedAccount = accountRepository.Update(user);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
