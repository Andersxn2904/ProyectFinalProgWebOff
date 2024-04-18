

using DanderiTV.Layer.Application.Enums;
using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.DataAccess.Contexts;
using System.Data;
using TrailersApp.Entity.Entities;

namespace DanderiTV.Layer.Application.Repositories
{
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        string tableName = nameof(Tables.Directors);
        private readonly IDbConnection _dbConnection;
        public DirectorRepository(DapperContext context) : base(context) { _dbConnection = context.CreateConnection(); }

    }
}
