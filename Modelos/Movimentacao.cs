using Plataforma_Investimento_AdeInvest.Models;

public class Movimentacao
     {
         public int Id { get; set; }
         public string Tipo { get; set; }
         public decimal Valor { get; set; }
         public DateTime DataMovimentacao { get; set; }
         public Conta? Conta { get; set; }
     }