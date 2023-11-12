namespace Plataforma_Investimento_AdeInvest.Models
{
    public class ContaViewModel
    {
        public int Id { get; set; }
        public decimal Saldo { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoDataHora { get; set; }
        public int InvestimentoId { get; set; }
        public string InvestimentoNome { get; set; }
        public byte InvestimentoRendimentoEmPorcentagem { get; set; }
        public byte InvestimentoResgate { get; set; }
        public string UsuarioClienteNome { get; set; }
        public int? DiasInvestimento { get; set; }
    }
}