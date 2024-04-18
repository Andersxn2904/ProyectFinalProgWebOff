using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Models;
using DanderiTV.SettingsView;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DanderiTV.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMovieService _movieService;

        public HomeController(IMovieService serieService) { _movieService = serieService; }

        public async Task<IActionResult> Index()
        {
            ViewData["ViewModeTV"] = "Series";
            return View(await _movieService.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ViewTrailer([FromRoute] int ID)
        {
           

            return RedirectToAction("Trailer", "Movie", new { id = ID });
           
        }


        [HttpPost]
		public IActionResult ChangeViewMode(bool isChecked)
		{
			if (isChecked)
			{
				GetViewMode.ViewMode = "light";
			}
			else
			{
				GetViewMode.ViewMode = "dark";
			}

			// Devuelve la URL de la vista a la que deseas redirigir
			return Json(new { url = Url.Action("Index") });
		}



	}
}
