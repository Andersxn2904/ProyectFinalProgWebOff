using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Serie;
using System.IO;
using TrailersApp.Entity.Entities;


namespace DanderiTV.Layer.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movierespository;
        public MovieService(IMovieRepository repository) { _movierespository = repository; }

        public async Task<Movie> CreateAsync(SaveMovieModel model)
        {
            var movie = new Movie() {
                Title = model.Title,
                Year = model.Year,
                Description = model.Description,
                ImagePath = model.ImagePath,
                Streams = 0,
                TrailerPath = model.TrailerPath,
                DirectorID = model.DirectorID,


            };
            Movie SerieAdded = await _movierespository.Add(movie);

            return SerieAdded;

        }


        public async Task<List<MovieViewModel>> GetAll() => await _movierespository.GetAllWithInclude();

        public async Task<MovieViewModel> GetByID(int ID) 
        {
            var serie = await _movierespository.FindByIDWithAll(ID);

            MovieViewModel movieVM = new();
            movieVM.ID = serie.ID;
            movieVM.Title = serie.Title;
            movieVM.Year = serie.Year;
            movieVM.TrailerPath = serie.TrailerPath;
            movieVM.ImagePath = serie.ImagePath;
            movieVM.Streams = serie.Streams;
            movieVM.Description = serie.Description;
            movieVM.Director = serie.Director;

            return movieVM;

                
        }


		public async Task<MovieViewModel> GetByIDModel(int ID)
		{
			var MovieGot = await _movierespository.FindByIDWithAll(ID);

            if (MovieGot != null)
            {
                MovieViewModel SMovieVM = new();
                SMovieVM.ID = MovieGot.ID;
                SMovieVM.Title = MovieGot.Title;
                SMovieVM.Year = MovieGot.Year;
                SMovieVM.TrailerPath = MovieGot.TrailerPath;
                SMovieVM.ImagePath = MovieGot.ImagePath;
                SMovieVM.Description = MovieGot.Description;
                SMovieVM.Director = MovieGot.Director;
                SMovieVM.DirectorID = MovieGot.DirectorID;
                return SMovieVM;
            }
            else
            {
                return null;
            }

            


		}

		public async Task<Movie> Update(SaveMovieModel Movie, int ID)
        {
            Movie MovieToUpdate = new();
            MovieToUpdate.ID = Movie.ID;
            MovieToUpdate.Title = Movie.Title;
            MovieToUpdate.Year = Movie.Year;
            MovieToUpdate.TrailerPath = Movie.TrailerPath;
            MovieToUpdate.ImagePath = Movie.ImagePath;
            MovieToUpdate.Description = Movie.Description;
            MovieToUpdate.DirectorID = Movie.DirectorID;


            var serieAdded = await _movierespository.Update(MovieToUpdate, ID);

            if (serieAdded != null)
            {
                return serieAdded;
            }
            else
            {
                return null;
            }

            
        }


	}
}
