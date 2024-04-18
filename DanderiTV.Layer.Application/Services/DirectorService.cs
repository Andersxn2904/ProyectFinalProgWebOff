using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using TrailersApp.Entity.Entities;

namespace DanderiTV.Layer.Application.Services
{
    public class DirectorService : IDirectorService
    {

        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }


        public async Task<List<Director>> GetAllModel()
        {
            var directors = (await _directorRepository.GetAll());
            return directors.ToList();
        }
    }
}
