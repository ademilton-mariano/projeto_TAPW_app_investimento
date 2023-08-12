namespace Plataforma_Investimento_AdeInvest.Models
{
    public class Investimento
    {
        public int Id { get; set; }
        public string TipoConta { get; set; }
        public double? Rendimento { get; set; }
        public int? TempoResgate { get; set; }
    }
}