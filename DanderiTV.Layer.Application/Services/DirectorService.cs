using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Actor;
using DanderiTV.Layer.Application.Models.Director;
using DanderiTV.Layer.Application.Repositories;
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

        public async Task<SaveDirectorModel> Create(SaveDirectorModel Smodel)
        {
            Director director = new();
            director.Name = Smodel.DirectorName;
            director.Lastname = Smodel.Lastname;
            
            var directorAdded = await _directorRepository.Add(director);

            SaveDirectorModel saveDirectorModel = new();
            saveDirectorModel.DirectorName = directorAdded.Name;
            saveDirectorModel.Lastname = directorAdded.Lastname;
            saveDirectorModel.ID = directorAdded.ID;

            return saveDirectorModel;

        }

        public async Task<SaveDirectorModel> Update(SaveDirectorModel model)
        {
            Director director = new();
            director.Name = model.DirectorName;
            director.Lastname= model.Lastname;
            director.ID = model.ID;

            var DirectorUpdated = await _directorRepository.Update(director, director.ID);

            SaveDirectorModel saveDirectorModel = new();
            saveDirectorModel.DirectorName = DirectorUpdated.Name;
            saveDirectorModel.Lastname= DirectorUpdated.Lastname;
            saveDirectorModel.ID= DirectorUpdated.ID;

            return saveDirectorModel;
        }

        public async Task<SaveDirectorModel> GetByIDSaveVM(int ID)
        {
            var director = await _directorRepository.FindById(ID);
            SaveDirectorModel model = new();
            model.DirectorName = director.Name;
            model.Lastname = director.Lastname;
            model.ID = director.ID;
            return model;

        }
        public async Task<bool> Delete(int ID)
        {
            var DirectorToDelete = await _directorRepository.FindById(ID);

            var delete = await _directorRepository.Delete(DirectorToDelete);

            return delete;
        }
    }
}
