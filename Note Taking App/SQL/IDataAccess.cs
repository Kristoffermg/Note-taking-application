using System.Collections.Generic;
using System.Threading.Tasks;
using Note_Taking_App.Data;

namespace Note_Taking_App.SQL
{
    public interface IDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string query, U parameters, string connectionString);
        List<ChildNotes> LoadData<T, U>(string query, U parameters, string connectionString);
        Task InsertData<T, U>(string query, U parameters, string connectionString);
        Task<int> LoadSingularDataValueAsync(string query, string connectionString);
        int LoadSingularDataValue(string query, string connectionString);
        void UpdateData<U>(string query, U parameters, string connectionString);
    }
}