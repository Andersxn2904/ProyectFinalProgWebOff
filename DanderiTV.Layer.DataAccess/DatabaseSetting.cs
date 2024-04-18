using DanderiTV.Layer.DataAccess.Contexts;


namespace DanderiTV.Layer.DataAccess
{
    public class DatabaseSetting
    {
        private readonly DapperContext _context;
        //public DatabaseSetting(DapperContext context)
        //{
        //    _context = context;
        //}

        //public void CreateDatabase(string dbName)
        //{
        //    var query = "SELECT * FROM sys.databases WHERE name = @name";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("name", dbName);
        //    using (var connection = _context.CreateConnection())
        //    {
        //        var records = connection.Query(query, parameters);
        //        if (!records.Any())
        //            connection.Execute($"CREATE DATABASE {dbName}");
        //    }
        //}

    }
}
