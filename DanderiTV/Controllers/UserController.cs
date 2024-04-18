using Microsoft.AspNetCore.Mvc;

namespace DanderiTV.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }




    }
}
