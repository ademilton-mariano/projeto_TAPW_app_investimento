using System;

namespace Plataforma_Investimento_AdeInvest.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string TipoMovimentacao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}