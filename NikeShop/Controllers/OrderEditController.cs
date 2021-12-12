using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NikeShop.Models;

namespace NikeShop.Controllers
{
    public class OrderEditController : Controller
    {
        // GET
        public IActionResult Index(int id)
        {
            var nike = ApplicationContext.db.Carts.Where(p => p.ID == id).FirstOrDefault();
            var size = Request.Form["size"].ToString();
            var country = Request.Form["countries"].ToString();

            if (ModelState.IsValid)
            {
                nike.Size = Convert.ToInt32(size);
                nike.Country = country;

                ApplicationContext.db.SaveChanges();
                
                return RedirectToAction("Cart", "Cart");
            }
            
            
            return RedirectToAction("Cart", "Cart");
        }
    }
}