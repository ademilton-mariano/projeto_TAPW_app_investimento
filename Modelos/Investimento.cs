namespace Plataforma_Investimento_AdeInvest.Models
{
    public class Investimento
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public byte Rendimento { get; set; }
        public byte TempoResgate { get; set; }
        public List<Conta> Conta { get; set; }
        public decimal SaldoPiso { get; set; }
        public decimal SaldoTeto { get; set; }
    }
}