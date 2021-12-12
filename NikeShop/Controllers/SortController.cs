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
    public class SortController : Controller
    {
        public IActionResult SortDate(int type)
        {
            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();
            List<Purchase> purch = null;


            if (type == 0)
            {
                purch = ApplicationContext.db.Purchases
                .Where(p => p.User == user).OrderBy(t => t.Date).ToList();
            }
            else if (type == 1)
            {
                purch = ApplicationContext.db.Purchases
                .Where(p => p.User == user).OrderByDescending(t => t.Date).ToList();
            }

            TempData["list"] = JsonSerializer.Serialize(purch);

            return RedirectToAction("UserAccount", "UserPage");
        }

        public IActionResult SortName(int type)
        {
            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();
            List<Purchase> purch = null;


            if (type == 0)
            {
                purch = ApplicationContext.db.Purchases
                .Where(p => p.User == user).OrderBy(t => t.Name).ToList();
            }
            else if (type == 1)
            {
                purch = ApplicationContext.db.Purchases
                .Where(p => p.User == user).OrderByDescending(t => t.Name).ToList();
            }

            TempData["list"] = JsonSerializer.Serialize(purch);

            return RedirectToAction("UserAccount", "UserPage");
        }

        public IActionResult SortPrice(int type)
        {
            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();
            List<Purchase> purch = null;


            if (type == 0)
            {
                purch = ApplicationContext.db.Purchases
                .Where(p => p.User == user).OrderBy(t => t.Price).ToList();
            }
            else if (type == 1)
            {
                purch = ApplicationContext.db.Purchases
                .Where(p => p.User == user).OrderByDescending(t => t.Price).ToList();
            }

            TempData["list"] = JsonSerializer.Serialize(purch);

            return RedirectToAction("UserAccount", "UserPage");
        }

        public IActionResult SortCountry(int type)
        {
            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();
            List<Purchase> purch = null;


            if (type == 0)
            {
                purch = ApplicationContext.db.Purchases
                .Where(p => p.User == user).OrderBy(t => t.Country).ToList();
            }
            else if (type == 1)
            {
                purch = ApplicationContext.db.Purchases
                .Where(p => p.User == user).OrderByDescending(t => t.Country).ToList();
            }

            TempData["list"] = JsonSerializer.Serialize(purch);

            return RedirectToAction("UserAccount", "UserPage");
        }

        public IActionResult SortSize(int type)
        {
            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();
            List<Purchase> purch = null;


            if (type == 0)
            {
                purch = ApplicationContext.db.Purchases
                .Where(p => p.User == user).OrderBy(t => t.Size).ToList();
            }
            else if (type == 1)
            {
                purch = ApplicationContext.db.Purchases
                .Where(p => p.User == user).OrderByDescending(t => t.Size).ToList();
            }

            TempData["list"] = JsonSerializer.Serialize(purch);

            return RedirectToAction("UserAccount", "UserPage");
        }
    }
}
