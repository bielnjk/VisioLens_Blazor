namespace VisioLens_Blazor.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public int Fotografo { get; set; }
        public int PacoteContratado { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorRestante { get; set; }
        public string? FormaPagamento { get; set; }
        public string? StatusPagamento { get; set; }
    }
}
