using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NikeShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace NikeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Catalog()
        {
            return View();
        }

        //public IActionResult Cart()
        //{
        //    return View();
        //}

        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        public IActionResult Admin()
        {
            return View("~/Views/UserPage/UserAccount.cshtml");
        }


    }
}
