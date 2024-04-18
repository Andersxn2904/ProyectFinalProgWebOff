
using TrailersApp.Entity.Entities;

namespace DanderiTV.Layer.Application.Interfaces.Services
{
    public interface IActorService
    {
        Task<List<Actor>> GetAllModel();


    }
}
