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

            var comando = _conexao.CreateCommand("SELECT * FROM cliente;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente();
                cliente.Id = leitor.GetInt32("id_cli");
                cliente.Nome = DAOHelper.GetString(leitor, "nome_cli");
                cliente.CPF = DAOHelper.GetString(leitor, "cpf_cli");
                cliente.Telefone = DAOHelper.GetString(leitor, "telefone_cli");
                cliente.Endereco = DAOHelper.GetString(leitor, "endereco_cli");
                cliente.Email = DAOHelper.GetString(leitor, "email_cli");

                lista.Add(cliente);
            }

            return lista;
        }

        public void Inserir(Cliente cliente)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cliente VALUES (null, @_nome, @_cpf, @_telefone, @_endereco, @_email)");

                comando.Parameters.AddWithValue("@_nome", cliente.Nome);
                comando.Parameters.AddWithValue("@_cpf", cliente.CPF);
                comando.Parameters.AddWithValue("@_telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@_endereco", cliente.Endereco);
                comando.Parameters.AddWithValue("@_email", cliente.Email);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
