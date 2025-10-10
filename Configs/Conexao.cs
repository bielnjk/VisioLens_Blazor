using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace VisioLens_Blazor.Configs
{
    public class Conexao
    {
        private readonly string _conexaoConnectionString;
        public Conexao(IConfiguration configuration)
        {
            _conexaoConnectionString = configuration.GetConnectionString("MySqlConnection") ?? "";
        }
        public MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(_conexaoConnectionString);
            conn.Open();
            return conn;
        }
        public MySqlCommand CreateCommand(string query, MySqlConnection? conn = null)
        {
            conn ??= GetConnection();
            return new MySqlCommand(query, conn);
        }
    }
}
