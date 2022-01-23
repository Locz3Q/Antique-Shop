using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Antique_Shop.Models;
using Antique_Shop.ViewModel;
using Antique_Shop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Antique_Shop.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Account> userManager;
        private readonly SignInManager<Account> signInManager;
        private readonly IPayment payment;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AccountController(UserManager<Account> userManager,
            SignInManager<Account> signInManager, IPayment payment, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.payment = payment;
            this.httpContextAccessor = httpContextAccessor;
    }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Login, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Registration(Registration model)
        {
            if (ModelState.IsValid)
            {
                var user = new Account
                {
                    UserName = model.Login,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Street = model.Street,
                    ApartmentNumber = model.ApartmentNumber,
                    Postcode = model.Postcode,
                    City = model.City,
                    AccountCreateDate = DateTime.Now,
                    Saldo = 0

                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                //@todo
               //errors

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSaldo(float number)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await userManager.FindByIdAsync(userId);
            payment.AddSaldo(currentUser, number);
            return RedirectToAction("index", "MyProfile");
        }

    }
}
