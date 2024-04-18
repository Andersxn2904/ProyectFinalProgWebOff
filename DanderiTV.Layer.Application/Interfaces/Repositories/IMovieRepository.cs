using DanderiTV.Layer.Application.Models.Serie;
using TrailersApp.Entity.Entities;

namespace DanderiTV.Layer.Application.Interfaces.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
		Task<List<MovieViewModel>> GetAllWithInclude();

        Task<MovieViewModel> FindByIDWithAll(int id);





    }
}
