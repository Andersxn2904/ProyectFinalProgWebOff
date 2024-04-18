

using TrailersApp.Entity.Entities;

namespace DanderiTV.Layer.Application.Interfaces.Services
{
    public interface IDirectorService
    {
        Task<List<Director>> GetAllModel();

    }
}
