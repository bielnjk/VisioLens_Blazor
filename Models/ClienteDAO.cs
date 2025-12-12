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

        // LISTAR TODOS
        public List<Cliente> ListarTodos()
        {
            var lista = new List<Cliente>();

            using var conn = _conexao.GetConnection();
            using var comando = _conexao.CreateCommand("SELECT * FROM cliente;", conn);
            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(Mapear(leitor));
            }

            return lista;
        }

        // CONSULTAR (filtros opcionais)
        public List<Cliente> Consultar(string? nome, string? telefone, string? email, string? cpf)
        {
            var lista = new List<Cliente>();

            using var conn = _conexao.GetConnection();

            string sql = @"SELECT * FROM cliente WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(nome)) sql += " AND nome_cli LIKE @nome";
            if (!string.IsNullOrWhiteSpace(telefone)) sql += " AND telefone_cli LIKE @telefone";
            if (!string.IsNullOrWhiteSpace(email)) sql += " AND email_cli LIKE @Email";
            if (!string.IsNullOrWhiteSpace(cpf)) sql += " AND cpf_cli LIKE @cpf";

            using var comando = _conexao.CreateCommand(sql, conn);

            if (!string.IsNullOrWhiteSpace(nome)) comando.Parameters.AddWithValue("@nome", "%" + nome + "%");
            if (!string.IsNullOrWhiteSpace(telefone)) comando.Parameters.AddWithValue("@telefone", "%" + telefone + "%");
            if (!string.IsNullOrWhiteSpace(email)) comando.Parameters.AddWithValue("@email", "%" + email + "%");
            if (!string.IsNullOrWhiteSpace(cpf)) comando.Parameters.AddWithValue("@cpf", "%" + cpf + "%");

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(Mapear(leitor));
            }

            return lista;
        }

        // BUSCAR POR ID
        public Cliente? BuscarPorId(int id)
        {
            using var conn = _conexao.GetConnection();
            using var comando = _conexao.CreateCommand(
                "SELECT * FROM cliente WHERE id_cli = @id;", conn
            );
            comando.Parameters.AddWithValue("@id", id);

            using var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                return Mapear(leitor);
            }

            return null;
        }

        // INSERIR
        public void Inserir(Cliente c)
        {
            using var conn = _conexao.GetConnection();

            string sql = @"INSERT INTO cliente 
                           (nome_cli, cpf_cli, telefone_cli, endereco_cli, email_cli)
                           VALUES (@nome, @cpf, @telefone, @endereco, @email);";

            using var comando = _conexao.CreateCommand(sql, conn);

            comando.Parameters.AddWithValue("@nome", c.Nome);
            comando.Parameters.AddWithValue("@cpf", c.CPF);
            comando.Parameters.AddWithValue("@telefone", c.Telefone);
            comando.Parameters.AddWithValue("@endereco", c.Endereco);
            comando.Parameters.AddWithValue("@email", c.Email);

            comando.ExecuteNonQuery();
        }

        // ATUALIZAR
        public void Atualizar(Cliente c)
        {
            using var conn = _conexao.GetConnection();

            string sql = @"UPDATE cliente SET
                           nome_cli = @nome,
                           cpf_cli = @cpf,
                           telefone_cli = @telefone,
                           endereco_cli = @endereco,
                           email_cli = @email
                           WHERE id_cli = @id;";

            using var comando = _conexao.CreateCommand(sql, conn);

            comando.Parameters.AddWithValue("@id", c.Id);
            comando.Parameters.AddWithValue("@nome", c.Nome);
            comando.Parameters.AddWithValue("@cpf", c.CPF);
            comando.Parameters.AddWithValue("@telefone", c.Telefone);
            comando.Parameters.AddWithValue("@endereco", c.Endereco);
            comando.Parameters.AddWithValue("@email", c.Email);

            comando.ExecuteNonQuery();
        }

        // EXCLUIR
        public bool Excluir(int id)
        {
            using var conn = _conexao.GetConnection();

            string sql = "DELETE FROM cliente WHERE id_cli = @id;";

            using var comando = _conexao.CreateCommand(sql, conn);
            comando.Parameters.AddWithValue("@id", id);

            int linhasAfetadas = comando.ExecuteNonQuery();

            return linhasAfetadas > 0;
        }

        // MAPEAMENTO PADRÃO
        private Cliente Mapear(MySqlDataReader leitor)
        {
            return new Cliente
            {
                Id = leitor.GetInt32("id_cli"),
                Nome = DAOHelper.GetString(leitor, "nome_cli"),
                CPF = DAOHelper.GetString(leitor, "cpf_cli"),
                Telefone = DAOHelper.GetString(leitor, "telefone_cli"),
                Endereco = DAOHelper.GetString(leitor, "endereco_cli"),
                Email = DAOHelper.GetString(leitor, "email_cli")
            };
        }
    }
}
