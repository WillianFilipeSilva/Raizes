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

        public async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);
            }
        }

        public async Task<IEnumerable<T>> ExecuteQuery<T>(string sql)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.QueryAsync<T>(sql);
            }
        }
    }
}
