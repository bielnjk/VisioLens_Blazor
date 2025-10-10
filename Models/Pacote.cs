namespace VisioLens_Blazor.Models
{
    public class Pacote
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public string? Destinatario { get; set; }
        public string? Dimensoes { get; set; }
    }
}
