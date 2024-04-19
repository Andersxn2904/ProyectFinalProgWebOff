
using DanderiTV.Layer.Application.Models.Actor;
using TrailersApp.Entity.Entities;

namespace DanderiTV.Layer.Application.Interfaces.Services
{
    public interface IActorService
    {
        Task<List<Actor>> GetAllModel();
        Task<SaveActorModel> GetByIDSaveVM(int ID);
        Task<ActorViewModel> Create(SaveActorModel model);
        Task<SaveActorModel> Update(SaveActorModel model);
        Task<bool> Delete(int ID);


    }
}
