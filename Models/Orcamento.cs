namespace VisioLens_Blazor.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public int Fotografo { get; set;}
        public string? PacoteDeFotos { get; set;}
        public decimal ValorTotal { get; set; }
        public string? Status { get; set; }
        public string? FormaDePagamento { get; set; }
        public int TipoDeSessao { get; set; }
    }
}
