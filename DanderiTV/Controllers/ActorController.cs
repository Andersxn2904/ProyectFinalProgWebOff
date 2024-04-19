using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Actor;
using DanderiTV.Layer.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DanderiTV.Controllers
{
    public class ActorController : Controller
    {
        public readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _actorService.GetAllModel());
        }
        public IActionResult Create()
        {
            SaveActorModel saveActorModel = new();
            return View("CreateActor", saveActorModel);
        }

        public async Task<IActionResult> Delete([FromRoute] int ID)
        {
            return View(await _actorService.GetByIDSaveVM(ID));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteActor(int ID)
        {
            var delete = await _actorService.Delete(ID);

            if (!delete)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Edit([FromRoute] int ID)
        {
            return View("CreateActor",await _actorService.GetByIDSaveVM(ID));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveActorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateActor", model);
            }
            var actorUpdated = await _actorService.Update(model);

            if (actorUpdated == null)
            {
                ViewBag.ErrorMessage = "Error while updating actor";

                return View("CreateActor", model);
            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Create(SaveActorModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateActor", vm);
            }
            var actor = await _actorService.Create(vm);

            if (actor == null)
            {
                ViewBag.ErrorMessage = "Error while creating new actor";
                return View("CreateActor", vm);
            }
            return RedirectToAction("Index");

        }


    }
}
