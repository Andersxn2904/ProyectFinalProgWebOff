using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Serie;
using DanderiTV.Layer.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrailersApp.Entity.Entities;

namespace DanderiTV.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IDirectorService _directorService;
        private readonly IActorService _actorService;

        public MovieController(IMovieService serieService, IDirectorService directorService, IActorService actorService)
        {
            _movieService = serieService;
            _directorService = directorService;
            _actorService = actorService;
        }

       
            public async Task<IActionResult> Trailer([FromRoute] int id)
            {
                var movie = await _movieService.GetByID(id);

                return View("Trailer",movie);

            }


        [HttpPost]
        public async Task<IActionResult> Create(SaveMovieModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateMovie",vm);
            }
            await _movieService.CreateAsync(vm);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }



        [HttpPost]
        public async Task<IActionResult> Edit(SaveMovieModel vm)
        {
            vm.Actors = await _actorService.GetAllModel();
            vm.Directors = await _directorService.GetAllModel();

            if (!ModelState.IsValid)
            {

                return View("CreateMovie", vm);
            }
            else
            {
                await _movieService.Update(vm, vm.ID);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetByIDModel(id);
            var actorGetAllTask = _actorService.GetAllModel();
            var directorGetAllTask = _directorService.GetAllModel();

            SaveMovieModel Svm = new()
            {
                ID = movie.ID,
                ImagePath = movie.ImagePath,
                TrailerPath = movie.TrailerPath,
                Title = movie.Title,
                Year = movie.Year,
                Description = movie.Description,
                Streams = movie.Streams,
                
                Actors = await actorGetAllTask,
                Directors = await directorGetAllTask


            };
            

            return View("CreateMovie", Svm);
        }


        public async Task<IActionResult> Create()
        {
          

            var actorGetAllTask = _actorService.GetAllModel();
            var directorGetAllTask = _directorService.GetAllModel();

            SaveMovieModel vm = new()
            {
                Actors = await actorGetAllTask,
                Directors = await directorGetAllTask


            };

            return View("CreateMovie", vm);
           
        }
    }
}
