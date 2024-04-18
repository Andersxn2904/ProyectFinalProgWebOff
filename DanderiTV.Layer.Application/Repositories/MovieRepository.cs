using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.DataAccess.Contexts;
using Dapper;
using System.Data;
using DanderiTV.Layer.Application.Enums;
using DanderiTV.Layer.Application.Models.Serie;
using TrailersApp.Entity.Entities;


namespace DanderiTV.Layer.Application.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
		string tableName = nameof(Tables.Movies);
		private readonly IDbConnection _dbConnection;
        public MovieRepository(DapperContext context) : base(context) { _dbConnection = context.CreateConnection(); }


        public async Task<List<MovieViewModel>> GetAllWithInclude()
        {
            IEnumerable<MovieViewModel> result = null;

            try
            {
                string query = "SELECT m.ID, m.Title, m.Year, m.Description, m.ImagePath, m.Streams, m.TrailerPath, d.Name AS Director " +
                       "FROM Movies m " +
                       "LEFT JOIN Directors d ON m.DirectorID = d.ID ";

                result = await _dbConnection.QueryAsync<MovieViewModel>(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result.ToList();
        }

        public async Task<MovieViewModel> FindByIDWithAll(int id)
        {
            MovieViewModel result = null;

            try
            {
                string query = "SELECT m.ID, m.Title, m.Year, m.Description, m.ImagePath, m.Streams, m.TrailerPath, d.Name AS Director " +
                       "FROM Movies m " +
                       "LEFT JOIN Directors d ON m.DirectorID = d.ID " +
                       "WHERE m.ID = @id";



                result = await _dbConnection.QueryFirstOrDefaultAsync<MovieViewModel>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }


    }
}
