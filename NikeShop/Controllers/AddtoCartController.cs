using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikeShop.Models;
using NikeShop.Models.DB.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NikeShop.Controllers
{
    public class AddtoCartController : Controller
    {
        [Authorize]
        public IActionResult Order(int id, int ident)
        {
            var nike = ApplicationContext.db.Nikes.Where(p => p.ID == id).FirstOrDefault();

            ViewBag.Name = nike.Name;
            ViewBag.Name2 = nike.Name2;
            ViewBag.Price = nike.Price;
            ViewBag.Path = nike.Path;
            ViewBag.Description = nike.Description;
            ViewBag.ID = nike.ID;
            
            return View();
        }

        [HttpPost]
        public IActionResult Order(int id, bool fsa = true)
        {
            var size = Request.Form["size"].ToString();
            var country = Request.Form["countries"].ToString();

            if (string.IsNullOrEmpty(size) || string.IsNullOrEmpty(country))
            {
                return RedirectToAction("Order", "AddtoCart");
            }
            else if(ModelState.IsValid)
            {
                var nike = ApplicationContext.db.Nikes.Where(p => p.ID == id).FirstOrDefault();

                var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();

                Cart cart = new Cart()
                {
                    Name = nike.Name + " " + nike.Name2,
                    Description = nike.Description,
                    Price = nike.Price,
                    Country = country,
                    Size = Convert.ToInt32(size),
                    Nike = nike,
                    User = user,
                    Path = nike.Path
                };

                ApplicationContext.db.Add(cart);
                ApplicationContext.db.SaveChanges();
            }
            
            return RedirectToAction("Catalog", "Home");


        }
    }
}


