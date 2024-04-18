using DanderiTV.Layer.Application.Enums;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace DanderiTV.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserController(IUserService userService, IHttpContextAccessor httpContext)
        {
            _contextAccessor = httpContext;
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

       


            return View();
        }





    }
}
