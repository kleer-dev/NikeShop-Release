using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NikeShop.Models;
using NikeShop.Models.DB.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace NikeShop.Controllers
{
    public class UserPageController : Controller
    {
        public IActionResult UserAccount()
        {
            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();
            List<Purchase> nike = null;

            try
            {
                nike = JsonSerializer.Deserialize<List<Purchase>>(TempData["list"].ToString());
            }
            catch 
            {
                nike = ApplicationContext.db.Purchases.Where(p => p.User.ID == userid).ToList();
            } 


            return View(nike);
        }

        [HttpPost]
        public IActionResult UserAccount(bool f)
        {
            HttpContext.SignOutAsync("Cookie");

            return RedirectToAction("Login", "Account");
        }


    }
}
