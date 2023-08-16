using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Note_Taking_App.SQL
{
    public class DataAccess : IDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string query, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(query, parameters);

                return rows.ToList();
            }
        }
        public async void InsertData<T, U>(string query, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                await connection.QueryAsync<T>(query, parameters);
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
    }
}