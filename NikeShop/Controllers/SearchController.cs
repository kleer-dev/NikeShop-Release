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
    public class SearchController : Controller
    {
        public IActionResult Search()
        {
            var field = Request.Form["field-search"].ToString();

            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();

            var purchases = ApplicationContext.db.Purchases.Where(p => p.User == user).ToList();

            var list = new List<Purchase>();

            foreach (var item in purchases)
            {
                if (item.Name.Contains(field))
                {
                    list.Add(item);
                }
                else if (item.Price.ToString().Contains(field))
                {
                    list.Add(item);
                }
                else if (item.Size.ToString().Contains(field))
                {
                    list.Add(item);
                }
                else if (item.Country.Contains(field))
                {
                    list.Add(item);
                }
            }

            foreach (var item in purchases)
            {
                list.Add(item);
            }

            TempData["list"] = JsonSerializer.Serialize(list.Distinct());

            return RedirectToAction("UserAccount", "UserPage");
        }
    }
}
