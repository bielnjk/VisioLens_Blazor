using MySql.Data.MySqlClient;
using VisioLens_Blazor.Models;

namespace VisioLens_Blazor.DAO
{
    public class CadastroDAO
    {
        private readonly string _conexao =
            "server=localhost;database=visioLens;user=bielnjk;password=root";

        public void Cadastrar(Cliente cliente)
        {
            // DEBUG: log no servidor para inspecionar valores antes do INSERT
            Console.WriteLine("DAO.Cadastrar recebeu cliente:");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(cliente));

            using var con = new MySqlConnection(_conexao);
            con.Open();

            string sql = @"INSERT INTO cliente 
                        (nome_cli, telefone_cli, email_cli, cpf_cli, endereco_cli)
                        VALUES (@Nome, @Telefone, @Email, @CPF, @Endereco)";

            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Nome", (object?)cliente.Nome ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefone", (object?)cliente.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)cliente.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CPF", (object?)cliente.CPF ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Endereco", (object?)cliente.Endereco ?? DBNull.Value);

            int affected = cmd.ExecuteNonQuery();
            Console.WriteLine($"ExecuteNonQuery retornou: {affected} linhas afetadas.");
        }
    }
}
