namespace Plataforma_Investimento_AdeInvest.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public double? Saldo { get; set; }
        public bool Ativa { get; set; }
    }
}