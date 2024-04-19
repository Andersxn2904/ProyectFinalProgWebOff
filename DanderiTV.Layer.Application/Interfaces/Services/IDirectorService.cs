

using DanderiTV.Layer.Application.Models.Director;
using TrailersApp.Entity.Entities;

namespace DanderiTV.Layer.Application.Interfaces.Services
{
    public interface IDirectorService
    {
        Task<List<Director>> GetAllModel();

        Task<SaveDirectorModel> GetByIDSaveVM(int ID);
        Task<bool> Delete(int ID);
        
        Task<SaveDirectorModel> Update(SaveDirectorModel model);
        Task<SaveDirectorModel> Create(SaveDirectorModel Smodel);

    }
}
