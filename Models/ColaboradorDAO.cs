using VisioLens_Blazor.Configs;

namespace VisioLens_Blazor.Models
{
    public class ColaboradorDAO
    {
        private readonly Conexao _conexao;

        public ColaboradorDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Colaborador> ListarTodos()
        {
            var lista = new List<Colaborador>();

            var comando = _conexao.CreateCommand("SELECT * FROM colaborador");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var colaborador = new Colaborador();
                colaborador.Id = leitor.GetInt32("id_colab");
                colaborador.Nome = DAOHelper.GetString(leitor, "nome_colab");
                colaborador.Data_Nascimento = leitor.GetDateTime("data_nascimento_colab");
                colaborador.Telefone = DAOHelper.GetString(leitor, "telefone_colab");
                colaborador.Email = DAOHelper.GetString(leitor, "email_colab");

                lista.Add(colaborador);
            }

            return lista;
        }

        public void Inserir(Colaborador colaborador)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO colaborador VALUES (null, @_nome, @_dataNascimeno, @_telefone, @_email)");

                comando.Parameters.AddWithValue("@_nome", colaborador.Nome);
                comando.Parameters.AddWithValue("@_dataNascimento", colaborador.Data_Nascimento);
                comando.Parameters.AddWithValue("@_telefone", colaborador.Telefone);
                comando.Parameters.AddWithValue("@_email", colaborador.Email);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
