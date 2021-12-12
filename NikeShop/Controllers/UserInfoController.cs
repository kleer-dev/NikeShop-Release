using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeShop.Controllers
{
    public class UserInfoController : Controller
    {
        public IActionResult UserAccont()
        {
            return View("~/Views/UserPage/UserAccount.cshtml");
        }
    }
}
