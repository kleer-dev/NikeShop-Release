using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeShop.Controllers
{
    public class RemoveFromCartController : Controller
    {
        public IActionResult Cart(int id)
        {


            return View("~/Views/Cart/Cart.cshtml");
        }
    }
}
