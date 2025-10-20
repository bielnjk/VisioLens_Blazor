using MySql.Data.MySqlClient;
using VisioLens_Blazor.Configs;

namespace VisioLens_Blazor.Models
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;

        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Cliente> ListarTodos()
        {
            var lista = new List<Cliente>();

            using var conn = _conexao.GetConnection();
            using var comando = _conexao.CreateCommand("SELECT * FROM cliente;", conn);
            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente
                {
                    Id = leitor.GetInt32("id_cli"),
                    Nome = DAOHelper.GetString(leitor, "nome_cli"),
                    CPF = DAOHelper.GetString(leitor, "cpf_cli"),
                    Telefone = DAOHelper.GetString(leitor, "telefone_cli"),
                    Endereco = DAOHelper.GetString(leitor, "endereco_cli"),
                    Email = DAOHelper.GetString(leitor, "email_cli")
                };

                lista.Add(cliente);
            }

            return lista;
        }
    }
}
