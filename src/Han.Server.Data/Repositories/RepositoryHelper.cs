using System;
using System.Data;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Han.Server.Data.Models;
using MySql.Data.MySqlClient;

namespace Han.Server.Data.Repositories
{
    public static class RepositoryHelper
    {
        public static async Task<ulong> InsertAsync<T>(T record) where T : class
        {
            using (var connection = new MySqlConnection(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")))
            {
                connection.Open();

                UseDatabase(connection);

                var castRecord = record as IRecord;
                castRecord.CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                await connection.InsertAsync<T>(castRecord as T);

                var id = GetLastInsertedId(connection);

                connection.Close();

                return id;
            }
        }

        public static async Task<T> GetByIdAsync<T>(ulong id) where T : class
        {
            using (var connection = new MySqlConnection(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")))
            {
                connection.Open();

                UseDatabase(connection);

                var record = await connection.GetAsync<T>(id);

                connection.Close();

                return record;
            }
        }

        public static async Task UpdateAsync<T>(T record) where T : class
        {
            using (var connection = new MySqlConnection(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")))
            {
                connection.Open();

                UseDatabase(connection);

                var castRecord = record as IRecord;
                castRecord.CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                await connection.UpdateAsync<T>(castRecord as T);

                connection.Close();
            }
        }

        private static void UseDatabase(IDbConnection connection)
        {
            var command = connection.CreateCommand();

            command.CommandText = "USE `Han`;";
            command.ExecuteNonQuery();
        }

        private static ulong GetLastInsertedId(IDbConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "SELECT LAST_INSERT_ID();";

            return (ulong)command.ExecuteScalar();
        }
    }
}
