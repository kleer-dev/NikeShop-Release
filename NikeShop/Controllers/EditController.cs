using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using NikeShop.Models;
using NikeShop.Models.DB.DBModels;

namespace NikeShop.Controllers
{
    public class EditController : Controller
    {
        public IActionResult Edit(int price, string name, string desc, string path, int ident)
        {
            ViewBag.Price = price;
            ViewBag.Name = name;
            ViewBag.Name2 = name;
            ViewBag.Description = desc;
            ViewBag.Path = path;
            ViewBag.ID = ident;
            
            return View("~/Views/AddtoCart/OrderEdit.cshtml");
        }

        
        public IActionResult Editt(int id)
        {
            return RedirectToAction("Index", "OrderEdit");
        }
    }
}