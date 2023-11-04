namespace Plataforma_Investimento_AdeInvest.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public decimal Saldo { get; set; }
        public bool Ativo { get; set; }
        public UsuarioCliente UsuarioCliente { get; set; }
        public List<Movimentacao> Movimentacao { get; set; }
        public Investimento Investimento { get; set; }
        public DateTime CriadoDataHora { get; set; }
    }
}