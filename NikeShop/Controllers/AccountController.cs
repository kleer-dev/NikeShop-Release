using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NikeShop.Models;
using NikeShop.Models.CombineModels;
using NikeShop.Models.DB.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NikeShop.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(CombineLoginRegistration model)
        {
            if (model.Registration != null)
            {
                var confirmUser = ApplicationContext.db.Users.Where(p =>
                p.PhoneNumber == model.Registration.PhoneNumber).FirstOrDefault();

                if (confirmUser == null)
                {
                    if (ModelState.IsValid)
                    {
                        User user = new User
                        {
                            Name = model.Registration.Login,
                            Password = model.Registration.Password,
                            PhoneNumber = model.Registration.PhoneNumber,
                        };

                        ApplicationContext.db.Users.Add(user);
                        ApplicationContext.db.SaveChanges();

                        var claim = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                            new Claim(ClaimTypes.Name, user.Name),
                            new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                            new Claim(ClaimTypes.Role, "User")
                        };

                        var ClaimIdentity = new ClaimsIdentity(claim, "Cookie");
                        var ClaimPrincipal = new ClaimsPrincipal(ClaimIdentity);


                        RedirectToAction("Index", "Home");
                    }
                }
                else if (confirmUser != null)
                {
                    ModelState.AddModelError("Пользователь существует", "Пользователь существует");
                }
            }
            else if (model.Login != null)
            {
                var confirmUser = ApplicationContext.db.Users.Where(p =>
                p.PhoneNumber == model.Login.PhoneNumber & p.Password == model.Login.Password).FirstOrDefault();

                List<Claim> claim;

                if (model != null)
                {
                    if (confirmUser != null)
                    {
                        if (ModelState.IsValid)
                        {
                            if (confirmUser.Role == "Admin")
                            {
                                claim = new List<Claim>
                                {
                                    new Claim(ClaimTypes.NameIdentifier, confirmUser.ID.ToString()),
                                    new Claim(ClaimTypes.Name, confirmUser.Name),
                                    new Claim(ClaimTypes.MobilePhone, confirmUser.PhoneNumber),
                                    new Claim(ClaimTypes.Role, "Admin")
                                };
                            }
                            else
                            {
                                claim = new List<Claim>
                                {
                                    new Claim(ClaimTypes.NameIdentifier, confirmUser.ID.ToString()),
                                    new Claim(ClaimTypes.Name, confirmUser.Name),
                                    new Claim(ClaimTypes.MobilePhone, confirmUser.PhoneNumber),
                                    new Claim(ClaimTypes.Role, "User")
                                };
                            }

                            var claimIdentity = new ClaimsIdentity(claim, "Cookie");
                            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                            HttpContext.SignInAsync("Cookie", claimPrincipal);

                            return Redirect("/Home/Index");
                        }
                    }
                }
            }

            return View(model);
        }

    }
}