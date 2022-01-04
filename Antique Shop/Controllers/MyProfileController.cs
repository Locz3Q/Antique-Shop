﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antique_Shop.Models;
using Antique_Shop.ViewModel;
using Antique_Shop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Antique_Shop.Controllers
{
    public class MyProfileController : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly SignInManager<Account> signInManager;
        private readonly IAccountRepository accountRepository;
        public MyProfileController(UserManager<Account> userManager, IAccountRepository accountRepository, SignInManager<Account> signInManager)
        {
            this.userManager = userManager;
            this.accountRepository = accountRepository;
            this.signInManager = signInManager;
        }
        public async Task <IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }

        [HttpGet]
        public async Task <IActionResult> EditPersonalData()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            PersonalDataViewModel _user = new PersonalDataViewModel
            {
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
        public async Task<IActionResult> EditPersonalData(PersonalDataViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);

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

        [HttpGet]
        public IActionResult EditEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmail(EditEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                
                var passwordValidator = new PasswordValidator<Account>();
                var result = await passwordValidator.ValidateAsync(userManager, user, model.Password);
                if (!result.Succeeded)
                    return View();

                await userManager.ChangeEmailAsync(user, model.Email, null);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditPassword(PasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                var passwordValidator = new PasswordValidator<Account>();
                var result = await passwordValidator.ValidateAsync(userManager, user, model.Password);
                if (!result.Succeeded)
                    return View();

                await userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);

                await signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        
    }
}
