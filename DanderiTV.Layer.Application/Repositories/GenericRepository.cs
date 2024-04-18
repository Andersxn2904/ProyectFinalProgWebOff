using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.DataAccess.Contexts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using Dapper;
using System.Text;

namespace DanderiTV.Layer.Application.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        IDbConnection _dbConnection;


        public GenericRepository(DapperContext context)
        {
            _dbConnection = context.CreateConnection();

        }

        public async Task<T> Add(T entity)
        {
            try
            {
                string tableName = GetTableName();
                string columns = GetColumns(excludeKey: true);
                string properties = GetPropertyName(excludeKey: true);
                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties}); SELECT SCOPE_IDENTITY();";

                var id = await _dbConnection.ExecuteScalarAsync<int>(query, entity);

                
                string selectQuery = $"SELECT * FROM {tableName} WHERE Id = @Id";
                var addedEntity = await _dbConnection.QuerySingleOrDefaultAsync<T>(selectQuery, new { Id = id });

                return addedEntity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(T entity)
        {
            int rowsEffected = 0;
            try
            {
                string tableName = GetTableName();
                string keyColumn = GetKeyColumnName();
                string keyProperty = GetKeyPropertyName();
                string query = $"DELETE FROM {tableName} WHERE {keyColumn} = @{keyProperty}";

                rowsEffected = _dbConnection.Execute(query, entity);
            }
            catch (Exception ex) { }

            return rowsEffected > 0 ? true : false;
        }

        public async Task<List<T>> GetAll()
        {
                 IEnumerable<T> result = null;

                try
                {
                    string tableName = GetTableName();
                    string query = $"SELECT * FROM {tableName}";

                    result = await _dbConnection.QueryAsync<T>(query);
                    result = result.ToList();
                }
                catch (Exception ex) { }

                return result.ToList();
        }

        public async Task<T> FindById(int Id)
        {
            IEnumerable<T> result = null;
            try
            {
                string tableName = GetTableName();
                string keyColumn = GetKeyColumnName();
                string query = $"SELECT * FROM {tableName} WHERE {keyColumn} = '{Id}'";

                result = await _dbConnection.QueryAsync<T>(query);
            }
            catch (Exception ex) { }

            return result.FirstOrDefault();
        }

        public async Task<T> Update(T entity, int Id)
        {
            try
            {
                string tableName = GetTableName();
                string keyColumn = GetKeyColumnName();
                string keyProperty = GetKeyPropertyName();

                StringBuilder query = new StringBuilder();
                query.Append($"UPDATE {tableName} SET ");

                foreach (var property in GetProperties(true))
                {
                    var columnAttr = property.GetCustomAttribute<ColumnAttribute>();

                    string propertyName = property.Name;
                    string columnName = columnAttr.Name;

                    query.Append($"{columnName} = @{propertyName},");
                }

                query.Remove(query.Length - 1, 1);

                query.Append($" WHERE {keyColumn} = @{keyProperty}");

               await _dbConnection.ExecuteAsync(query.ToString(), entity);

                // Recuperar la entidad actualizada
                string selectQuery = $"SELECT * FROM {tableName} WHERE {keyColumn} = @{keyProperty}";
                var updatedEntity = await _dbConnection.QuerySingleOrDefaultAsync<T>(selectQuery, new { Id = Id });

                return updatedEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        #region Shared Methods Private

        //Get the column name based on the Entity T name
        private string GetTableName()
        {
            string tableName = "";
            var type = typeof(T);
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            if (tableAttr != null)
            {
                tableName = tableAttr.Name;
                return tableName;
            }
            return type.Name + "s";
        }
         // Get the column key based on the  entity T
        public static string GetKeyColumnName()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object[] KeyAttributes = property.GetCustomAttributes(typeof(KeyAttribute), true);

                if (KeyAttributes != null && KeyAttributes.Length > 0)
                {
                    object[] columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                    if (columnAttributes != null && columnAttributes.Length > 0)
                    {
                        ColumnAttribute columnAttribute = (ColumnAttribute)columnAttributes[0];
                        return columnAttribute.Name;
                    }
                    else
                    {
                        return property.Name;
                    }
                }
            }
            return null;
        }
        // Get the table's name based on the name of ColumnAttributes of entity T
        private string GetColumns(bool excludeKey = false)
        {
            var type = typeof(T);
            var columns = string.Join(", ", type.GetProperties()
                .Where(p => !excludeKey || !p.IsDefined(typeof(KeyAttribute)))
                .Select(p =>
                {
                    var columnAttr = p.GetCustomAttribute<ColumnAttribute>();
                    return columnAttr != null ? columnAttr.Name : p.Name;
                }));
            return columns;
        }

        // Get the properties's name based on the name of properties of entity T
        protected string GetPropertyName(bool excludeKey = false)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

            var values = string.Join(", ", properties.Select(p =>
            {

                return $"@{p.Name}";

            }));

            return values;


        }
        // Get the properties based on the  entity
        protected IEnumerable<PropertyInfo> GetProperties(bool excludeKey = false)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

            return properties;
        }
        // Get the column's name key of entity T
        protected string GetKeyPropertyName()
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.GetCustomAttribute<KeyAttribute>() != null);

            if (properties.Any())
            {
                return properties.FirstOrDefault().Name;
            }
            return null;
        }





        #endregion

    }
}
