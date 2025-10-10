using VisioLens_Blazor.Configs;

namespace VisioLens_Blazor.Models
{
    public class OrcamentoDAO
    {
        private readonly Conexao _conexao;

        public OrcamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Orcamento> ListarTodos()
        {
            var lista = new List<Orcamento>();

            var comando = _conexao.CreateCommand("SELECT * FROM orcamento;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var orcamento = new Orcamento();
                orcamento.Id = leitor.GetInt32("id_orc");
                orcamento.Cliente = leitor.GetInt32("id_cli_fk");
                orcamento.Fotografo = leitor.GetInt32("id_colab_fk");
                orcamento.PacoteDeFotos = DAOHelper.GetString(leitor, "pacote_fotos_orc");
                orcamento.ValorTotal = leitor.GetDecimal("valor_total_orc");
                orcamento.Status = DAOHelper.GetString(leitor, "status_orc");
                orcamento.FormaDePagamento = DAOHelper.GetString(leitor, "forma_pagamento_orc");
                orcamento.TipoDeSessao = leitor.GetInt32("id_tip_ses_fk");

                lista.Add(orcamento);
            }

            return lista;
        }

        public void Inserir(Orcamento orcamento)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO orcamento VALUES (null, @_cliente, @_fotografo, @_pacoteDeFoto, @_valorTotal, @_status, @_formaDePagamento, @_tipoDeSessao)");

                comando.Parameters.AddWithValue("@_cliente", orcamento.Cliente);
                comando.Parameters.AddWithValue("@_fotografo", orcamento.Fotografo);
                comando.Parameters.AddWithValue("@_pacoteDeFoto", orcamento.PacoteDeFotos);
                comando.Parameters.AddWithValue("@_valorTotal", orcamento.ValorTotal);
                comando.Parameters.AddWithValue("@_status", orcamento.Status);
                comando.Parameters.AddWithValue("@_formaDePagamento", orcamento.FormaDePagamento);
                comando.Parameters.AddWithValue("@_tipoDeSessao", orcamento.TipoDeSessao);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
