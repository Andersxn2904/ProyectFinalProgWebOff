using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Director;
using Microsoft.AspNetCore.Mvc;

namespace DanderiTV.Controllers
{
    public class DirectorController : Controller
    {
        public readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _directorService.GetAllModel());
        }
        public IActionResult Create()
        {
            SaveDirectorModel saveDirectorModel = new SaveDirectorModel();
            return View("CreateDirector", saveDirectorModel);
        }

        public async Task<IActionResult> Delete([FromRoute] int ID)
        {
            return View(await _directorService.GetByIDSaveVM(ID));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteActor(int ID)
        {
            var delete = await _directorService.Delete(ID);

        
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit([FromRoute] int ID)
        {
            return View("CreateDirector", await _directorService.GetByIDSaveVM(ID));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveDirectorModel model)
            {
            if (!ModelState.IsValid)
            {
                return View("CreateDirector", model);
            }
            var actorUpdated = await _directorService.Update(model);

            if (actorUpdated == null)
            {
                ViewBag.ErrorMessage = "Error while updating director";

                return View("CreateDirector", model);
            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Create(SaveDirectorModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateDirector", vm);
            }
            var actor = await _directorService.Create(vm);

            if (actor == null)
            {
                ViewBag.ErrorMessage = "Error while creating new director";
                return View("CreateDirector", vm);
            }
            return RedirectToAction("Index");

        }
    }
}
