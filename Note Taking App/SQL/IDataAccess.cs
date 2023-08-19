using System.Collections.Generic;
using System.Threading.Tasks;

namespace Note_Taking_App.SQL
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string query, U parameters, string connectionString);
        void InsertData<T, U>(string query, U parameters, string connectionString);
        int LoadSingularDataValue(string query, string connectionString);
        void UpdateData<U>(string query, U parameters, string connectionString);
    }
}