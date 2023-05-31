using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username
            };
            if (p.Password == p.ConfirmPassword) //şifre arka tarafta hash işlemi ile gidileceği için böyle bir işlem yapıldı
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
        
        //public async Task<IActionResult> Singup(UserRegisterViewModel p)
        //{
        //    AppUser appUser = new AppUser()
        //    {
        //        Name = p.Name,
        //        Surname=p.Surname,
        //        Email=p.Mail,
        //        UserName=p.UserName
        //    };
        //    if (p.Password==p.ConfirmPassword) //şifre arka tarafta hash işlemi ile gidileceği için böyle bir işlem yapıldı
        //    {
        //        var result = await _userManager.CreateAsync(appUser, p.Password);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("SıgIn");
        //        }
        //        else
        //        {
        //            foreach (var item in result.Errors)
        //            {
        //                ModelState.AddModelError("", item.Description);
        //            }
        //        }
        //    }
        //    return View(p);
        //}
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
