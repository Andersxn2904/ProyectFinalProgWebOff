﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace DanderiTV.Layer.DataAccess.Contexts
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration) { _configuration = configuration; }

        public IDbConnection CreateConnection()
        => new SqlConnection(_configuration.GetConnectionString("ConnetionMaster"));

    }
}
