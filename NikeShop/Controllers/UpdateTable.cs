using Microsoft.AspNetCore.Mvc;

namespace NikeShop.Controllers
{
    public class UpdateTable : Controller
    {
        // GET
        public IActionResult Update()
        {
            return RedirectToAction("UserAccount", "UserPage");
        }
    }
}