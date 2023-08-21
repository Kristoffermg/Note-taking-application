using System.Collections.Generic;
using System.Threading.Tasks;
using Note_Taking_App.SqlData;

namespace Note_Taking_App.SQL
{
    public interface IDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string query, U parameters);
        Task InsertData<T>(string query, T parameters, string connectionString);
        Task<int> LoadSingularDataValueAsync(string query, string connectionString);
        int LoadSingularDataValue<T>(string query, T parameters, string connectionString);
        void UpdateData<U>(string query, U parameters, string connectionString);
    }
}