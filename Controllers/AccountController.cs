using Microsoft.AspNetCore.Mvc;

namespace WebFrontToBack.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
