using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NikeShop.Models;
using NikeShop.Models.DB.DBModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace NikeShop.Controllers
{
    public class CartController : Controller
    {
        private int userId;

        [Authorize]
        public IActionResult Cart()
        {
            userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var cart = ApplicationContext.db.Carts.Where(p => p.User.ID == userId).ToList();

            return View(cart);
        }

        [HttpPost]
        [ActionName("Remove")]
        public IActionResult Cart(int id)
        {
            var cart = ApplicationContext.db.Carts.Where(p => p.ID == id).FirstOrDefault();

            ApplicationContext.db.Remove(cart);
            ApplicationContext.db.SaveChanges();

            return RedirectToAction("Cart", "Cart");
        }

        [HttpPost]
        [ActionName("PurchaseDb")]
        public IActionResult Cart(int id, bool f) //!!!
        {
            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();

            var cart = ApplicationContext.db.Carts.Where(p => p.User.ID == userid && p.ID == id).FirstOrDefault();

            DateTime currentDate = DateTime.Now;

            Purchase purchase = new Purchase
            {
               
                Name = cart.Name,
                Price = cart.Price,
                Country = cart.Country,
                Size = cart.Size,
                User = user
            };

            ApplicationContext.db.Purchases.Add(purchase);
            ApplicationContext.db.Remove(cart);
            ApplicationContext.db.SaveChanges();

            return RedirectToAction("Cart", "Cart");
        }
    }
}
