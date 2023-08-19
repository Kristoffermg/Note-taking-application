using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Note_Taking_App.Data;

namespace Note_Taking_App.SQL
{
    public class DataAccess : IDataAccess
    {
        public async Task<List<T>> LoadDataAsync<T, U>(string query, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(query, parameters);

                return rows.ToList();
            }
        }

        public List<ChildNotes> LoadData<T, U>(string query, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = connection.QueryAsync<T>(query, parameters);

                return null;
            }
        }

        public async Task InsertData<T, U>(string query, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                await connection.QueryAsync<T>(query, parameters);
            }
        }
        public async Task <int>LoadSingularDataValueAsync(string query, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var row = connection.Query(query);
                dynamic result = row.SingleOrDefault();
                if (result.value == null) return 0;
                return result.value;
            }
        }

        public int LoadSingularDataValue(string query, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var row = connection.Query(query);
                dynamic result = row.SingleOrDefault();
                if (result.value == null) return 0;
                return result.value;
            }
        }

        public async void UpdateData<U>(string query, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                await connection.QueryAsync(query, parameters);
            }
        }
    }
}