using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
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
            var Actors = (await _actorRepository.GetAll());
            return Actors.ToList();
        }


    }
}
