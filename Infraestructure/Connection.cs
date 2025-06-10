using Dapper;
using MySql.Data.MySqlClient;

namespace Raizes.Infraestructure
{
    public class Connection
    {
        protected string connectionString = "Server=localhost;Database=raizes;User=root;Password=root;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public async Task<int> ExecuteAsync(string sql, object param)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, param);
            }
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object? param = null)
        {
            using (MySqlConnection con = GetConnection())
            {
                if (param is null)
                    return await con.QueryAsync<T>(sql);

                return await con.QueryAsync<T>(sql, param);
            }
        }

        public async Task<T> ExecuteQueryFirstAsync<T>(string sql, object param)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.QueryFirstAsync<T>(sql, param);
            }
        }
    }
}
