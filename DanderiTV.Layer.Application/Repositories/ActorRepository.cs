
using DanderiTV.Layer.Application.Enums;
using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.DataAccess.Contexts;
using System.Data;
using TrailersApp.Entity.Entities;

namespace DanderiTV.Layer.Application.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        string tableName = nameof(Tables.Actors);
        private readonly IDbConnection _dbConnection;
        public ActorRepository(DapperContext context) : base(context) { _dbConnection = context.CreateConnection(); }

    }
}
