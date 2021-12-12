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
    public class FiltrController : Controller
    {
        //int userid;
        //User user;

        //public FiltrController()
        //{
        //    userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        //    user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();
        //}

        public IActionResult Filtr()
        {
            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();


            var zn = Request.Form["filtr-value"].ToString();
            var filtrType = Request.Form["hide1"].ToString();

            List<Purchase> filtrResult = null;

            if (filtrType == "date")
            {
                filtrResult = ApplicationContext.db.Purchases.Where(p => p.User == user)
                    .Where(p => p.Date.ToString().Contains(zn)).ToList();
            }
            else if(filtrType == "name")
            {
                filtrResult = ApplicationContext.db.Purchases.Where(p => p.User == user)
                    .Where(p => p.Name.Contains(zn)).ToList();
            }
            else if (filtrType == "price")
            {
                filtrResult = ApplicationContext.db.Purchases.Where(p => p.User == user)
                    .Where(p => p.Price.ToString().Contains(zn)).ToList();
            }
            else if (filtrType == "country")
            {
                filtrResult = ApplicationContext.db.Purchases.Where(p => p.User == user)
                    .Where(p => p.Country.Contains(zn)).ToList();
            }
            else if (filtrType == "size")
            {
                filtrResult = ApplicationContext.db.Purchases.Where(p => p.User == user)
                    .Where(p => p.Size.ToString().Contains(zn)).ToList();
            }

            TempData["list"] = JsonSerializer.Serialize(filtrResult);

            return RedirectToAction("UserAccount", "UserPage");
        }
    }
}
