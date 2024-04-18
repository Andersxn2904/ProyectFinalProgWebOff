
using DanderiTV.Layer.Application.Models.Serie;
using TrailersApp.Entity.Entities;


namespace DanderiTV.Layer.Application.Interfaces.Services
{
	public interface IMovieService
	{

		Task<List<MovieViewModel>> GetAll();
		Task<Movie> CreateAsync(SaveMovieModel model);
		Task<MovieViewModel> GetByID(int ID);
		Task<Movie> Update(SaveMovieModel MovieToAdd, int id);
		Task<MovieViewModel> GetByIDModel(int ID);


        //Task<List<Movie>> GetAllModel();


    }
}
