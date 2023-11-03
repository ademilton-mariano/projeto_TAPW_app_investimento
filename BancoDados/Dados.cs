using Microsoft.EntityFrameworkCore;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.BancoDados;

public class Dados : DbContext
{
    public DbSet<UsuarioCliente> UsuarioCliente { get; set; }
    public DbSet<Conta> Conta { get; set; }
    public DbSet<Investimento> Investimento { get; set; }
    public DbSet<Movimentacao> Movimentacao { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(
            "Data Source=ADEMILTON;Initial Catalog=AdeINvest;Integrated Security=True;Encrypt=False;");
}