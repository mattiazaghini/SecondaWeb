﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zaghini.Mattia._5H.SecondaWeb.Models;
using Zaghini.Mattia._5H.SecondaWeb.dto;
using Microsoft.AspNetCore.Identity;

namespace Zaghini.Mattia._5H.SecondaWeb.Controllers
{
    public class AccountController : Controller
    {
        //private readonly ILogger<AccountController> _logger;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registra()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registra(RegistraDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto user)
        {
            if (ModelState.IsValid)
            {
               var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

               if (result.Succeeded) {
                   return RedirectToAction("Index", "Home");
               }
               else
               {
                ModelState.AddModelError(string.Empty, "Login error");
               }
            }
            return View(user); 
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        ///////////////////////////////////////////////////////
        [Authorize]
        [HttpGet] 
        public IActionResult Upload()
        {
            return View();   
        }

        [Authorize]
        [HttpGet]
        public IActionResult Privacy()
        {
                return View("~/Views/Home/Privacy.cshtml");
           
        }

        [Authorize]
        [HttpGet]
        public IActionResult Elenco()
        {
                var db=new DBContext();
                return View("~/Views/Home/Elenco.cshtml",db);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Prenota()
        {
           
                return View("~/Views/Home/Prenota.cshtml");
      
        }
    }
}
