namespace Plataforma_Investimento_AdeInvest.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public double? Saldo { get; set; }
        public bool Ativa { get; set; }
        public UsuarioCliente UsuarioCliente { get; set; }
        public List<Movimentacao> Movimentacao { get; set; }
        public Investimento Investimento { get; set; }
    }
}