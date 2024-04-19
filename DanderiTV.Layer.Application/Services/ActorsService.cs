using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Actor;
using TrailersApp.Entity.Entities;


namespace DanderiTV.Layer.Application.Services
{
    public class ActorsService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorsService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }



        public async Task<List<Actor>> GetAllModel()
        {
            var Actors = await _actorRepository.GetAll();
            return Actors.ToList();
        }

        public async Task<ActorViewModel> Create(SaveActorModel model)
        {
            Actor actor = new();
            actor.Name = model.ActorName;
            actor.Lastname = model.Lastname;
            var ActorAdded =  await _actorRepository.Add(actor);
            ActorViewModel actorVM = new();
            actorVM.Name = ActorAdded.Name;
            actor.Lastname = ActorAdded.Lastname;
            actor.ID = actorVM.ID;
            return actorVM;
        }

        public async Task<SaveActorModel> GetByIDSaveVM(int ID)
        {
            var actor = await _actorRepository.FindById(ID);
            SaveActorModel model = new();
            model.ActorName = actor.Name;
            model.Lastname = actor.Lastname;
            model.ID = actor.ID;
            return model;
            
        }
        public async Task<bool> Delete(int ID)
        {
            var ActorToDelete = await _actorRepository.FindById(ID);

            var delete = await _actorRepository.Delete(ActorToDelete);

            return delete;
        }

        public async Task<SaveActorModel> Update(SaveActorModel model)
        {
            Actor actor = new();
            actor.Name = model.ActorName;
            actor.Lastname = model.Lastname;
            actor.ID = model.ID;

            var actorAdded = await _actorRepository.Update(actor, actor.ID);

            SaveActorModel actorVM = new();
            actorVM.ActorName = actorAdded.Name;
            actorVM.Lastname = actorAdded.Lastname;
            actorVM.ID = actorAdded.ID;

            return actorVM; 

        }
    }
}
