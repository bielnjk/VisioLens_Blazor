using VisioLens_Blazor.Configs;
namespace VisioLens_Blazor.Models
{
    public class PacoteDAO
    {
        private readonly Conexao _conexao;

        public PacoteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Pacote> ListarTodos()
        {
            var lista = new List<Pacote>();

            var comando = _conexao.CreateCommand("SELECT * FROM pacote;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var pacote = new Pacote();
                pacote.Id = leitor.GetInt32("id_pac");
                pacote.Nome = DAOHelper.GetString(leitor, "nome_pac");
                pacote.Descricao = DAOHelper.GetString(leitor, "descricao_pac");
                pacote.Valor = leitor.GetDecimal("valor_pac");
                pacote.Destinatario = DAOHelper.GetString(leitor, "destinatario_pac");
                pacote.Dimensoes = DAOHelper.GetString(leitor, "dimensões_pac");

                lista.Add(pacote);
            }

            return lista;
        }

        public void Inserir(Pacote pacote)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO pacote VALUES (null, @_nome, @_descricao, @_valor, @_destinatario, @_dimensoes)");

                comando.Parameters.AddWithValue("@_nome", pacote.Nome);
                comando.Parameters.AddWithValue("@_descricao", pacote.Descricao);
                comando.Parameters.AddWithValue("@_valor", pacote.Valor);
                comando.Parameters.AddWithValue("@_destinatario", pacote.Destinatario);
                comando.Parameters.AddWithValue("@_dimensoes", pacote.Dimensoes);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
