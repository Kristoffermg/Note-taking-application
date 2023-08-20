﻿using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Note_Taking_App.SqlData;

namespace Note_Taking_App.SQL
{
    public class DataAccess : IDataAccess
    {
        //public readonly string connectionString = "Server=krishusdata.mysql.database.azure.com;Port=3306;database=NoteTakingApp;user id=kmg;password=krissupersecretpassword0!";

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

        public async Task InsertData<T>(string query, T parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {

                //await connection.ExecuteAsync(query);
                await connection.ExecuteAsync(query, parameters);
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

        public int LoadSingularDataValue<T>(string query, T parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var row = connection.Query(query, parameters);
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