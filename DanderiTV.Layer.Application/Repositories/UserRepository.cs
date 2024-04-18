using DanderiTV.Layer.Application.Enums;
using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Models.User;
using DanderiTV.Layer.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using TrailersApp.Entity.Entities;

namespace DanderiTV.Layer.Application.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        string tableName = nameof(Tables.Users);
        private readonly IDbConnection _dbConnection;
        public UserRepository(DapperContext context) : base(context) { _dbConnection = context.CreateConnection(); }

        public async Task<User> GetUser(SignInRequest loginModel)
        {

            string query = $"SELECT * FROM {tableName} WHERE UserName = '{loginModel.UserName}' AND Password = '{loginModel.Password}';";

            var user = await _dbConnection.QueryFirstOrDefaultAsync<User>(query);

            return user;

        }

        public async Task<bool> GetUserByUsernameBOOLResponse(string Username)
        {
            string query = $"SELECT * FROM {tableName} WHERE UserName = '{Username}';";

            var user = await _dbConnection.QueryAsync<User>(query);
            var userList = user.ToList();

            if (user != null || userList.Count != 0)
            {
                return true;
            }
            return false;
          

        }

        public override async Task<User> Add(User entity)
        {
            try
            {
              
                string query = $"INSERT INTO {tableName} (ID,UserName,Pasword,Role) " +
                    $"VALUES ({entity.ID},{entity.UserName},{entity.Password},{entity.Role}); SELECT SCOPE_IDENTITY();";

                


                string selectQuery = $"SELECT * FROM {tableName} WHERE ID = @Id";

                var addedEntity = await _dbConnection.QuerySingleOrDefaultAsync<User>(selectQuery, new { Id = entity.ID });

                return addedEntity != null ? addedEntity : null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }






    }
}
