using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using NikeShop.Models;
using NikeShop.Models.DB.DBModels;

namespace NikeShop.Controllers
{
    public class ClearTableController : Controller
    {
        // GET
        public IActionResult Clear()
        {
            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            using (ApplicationContext context = new ApplicationContext())  
            {  
                var employees = context.Purchases.Where(p => p.User.ID == userid).ToList();  
                context.Purchases.RemoveRange(employees);  
                context.SaveChanges();  
            }  
            
            ApplicationContext.db.SaveChanges();
            
            return RedirectToAction("UserAccount", "UserPage");
        }
    }
}