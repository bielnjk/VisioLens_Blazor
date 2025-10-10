using VisioLens_Blazor.Configs;

namespace VisioLens_Blazor.Models
{
    public class PagamentoDAO
    {
        private readonly Conexao _conexao;

        public PagamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Pagamento> ListarTodos()
        {
            var lista = new List<Pagamento>();

            var comando = _conexao.CreateCommand("SELECT * FROM pagamento");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var pagamento = new Pagamento();
                pagamento.Id = leitor.GetInt32("id_colab");
                pagamento.Cliente = leitor.GetInt32("id_cli_fk");
                pagamento.Fotografo = leitor.GetInt32("id_colab_fk");
                pagamento.PacoteContratado = leitor.GetInt32("id_pac_fk");
                pagamento.ValorPago = leitor.GetDecimal("valor_pago_pag");
                pagamento.ValorTotal = leitor.GetDecimal("valor_total_pag");
                pagamento.ValorRestante = leitor.GetDecimal("valor_restante_pag");
                pagamento.FormaPagamento = DAOHelper.GetString(leitor, "forma_pag");
                pagamento.StatusPagamento = DAOHelper.GetString(leitor, "status_pag");


                lista.Add(pagamento);
            }

            return lista;
        }

        public void Inserir(Pagamento pagamento)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO pagamento VALUES (null, @_cliente, @_fotografo, @_pacote, @_valorPago, @_valorTotal, @_valorRestante, @_formaPagamento, @_statusPagamento)");

                comando.Parameters.AddWithValue("@_cliente", pagamento.Cliente);
                comando.Parameters.AddWithValue("@_fotografo", pagamento.Fotografo);
                comando.Parameters.AddWithValue("@_pacote", pagamento.PacoteContratado);
                comando.Parameters.AddWithValue("@_valorPago", pagamento.ValorPago);
                comando.Parameters.AddWithValue("@_valorTotal", pagamento.ValorTotal);
                comando.Parameters.AddWithValue("@_valorRestante", pagamento.ValorRestante);
                comando.Parameters.AddWithValue("@_formaPagamento", pagamento.FormaPagamento);
                comando.Parameters.AddWithValue("@_statusPagamento", pagamento.StatusPagamento);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
