using DanderiTV.Layer.Application.Enums;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Helpers;
using DanderiTV.Layer.Application.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailersApp.Entity.Entities;

namespace DanderiTV.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public UserController(IUserService userService, IHttpContextAccessor httpContext)
        {
            _httpcontextAccessor = httpContext;
            _userService = userService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Register()
        {
            RegisterRequest requestRegis = new()
            {
                UserName = "AndyMota",
                Password = "#@20AndyAndy",
                Role = nameof(RolesApp.USERAPPLICATION)
            };
            await _userService.RegisterUserApp(requestRegis);
            return View();
        }

        public async Task<IActionResult> Login(SignInRequest requestSignIn)
        {
           
           var userLoged = await _userService.Login(requestSignIn);

            if (userLoged != null)
            {
                HttpContext.Session.SetUserApp<UserAppContext>("UserApp", userLoged);

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "Incorrect access data.");
            }




            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "UserApp", action = "Login" });
        }




    }
}
