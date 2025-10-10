namespace VisioLens_Blazor.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int? Cliente { get; set; }
        public DateTime Data {  get; set; }
        public int TipoDeSessao { get; set; }
        public string? Duracao { get; set; }
        public int Fotografo { get; set; }
        public string? Observacao { get; set;}
    }
}
