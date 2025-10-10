using VisioLens_Blazor.Configs;
namespace VisioLens_Blazor.Models
{
    public class AgendamentoDAO
    {
        private readonly Conexao _conexao;

        public AgendamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Agendamento> ListarTodos()
        {
            var lista = new List<Agendamento>();

            var comando = _conexao.CreateCommand("SELECT * FROM agendamento;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var agendamento = new Agendamento 
                {
                    Id = leitor.GetInt32("id_agen"),
                    Cliente = leitor.GetInt32("id_cli_fk"),
                    Data = leitor.GetDateTime("data_agen"),
                    TipoDeSessao = leitor.GetInt32("id_tip_ses_fk"),
                    Duracao = DAOHelper.GetString(leitor, "duracao_agen"),
                    Fotografo = leitor.GetInt32("id_colab_fk"),
                    Observacao = DAOHelper.GetString(leitor, "observação_agen")
                };

                lista.Add(agendamento);
            }

            return lista;
        }

        public void Inserir(Agendamento agendamento)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO agendamento VALUES (null, @_cliente, @_data, @_tipoSessao, @_duracao, @_fotografo, @_observacao)");

                comando.Parameters.AddWithValue("@_cliente", agendamento.Cliente);
                comando.Parameters.AddWithValue("@_data", agendamento.Data);
                comando.Parameters.AddWithValue("@_tipoSessao", agendamento.TipoDeSessao);
                comando.Parameters.AddWithValue("@_duracao", agendamento.Duracao);
                comando.Parameters.AddWithValue("@_fotografo", agendamento.Fotografo);
                comando.Parameters.AddWithValue("@_observacao", agendamento.Observacao);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
