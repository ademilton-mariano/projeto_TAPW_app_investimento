using AdeInvest.BancoDados;
using Microsoft.EntityFrameworkCore;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Repositorios;

public class MovimentacaoRepositorio : IMovimentacaoRepositorio
{
    private readonly Dados _dados;

    public MovimentacaoRepositorio(Dados dados)
    {
        _dados = dados;
    }

    public void AdicionarMovimentacao(Movimentacao movimentacao)
    {
        _dados.Movimentacao.Add(movimentacao);
        _dados.SaveChanges();
    }

    public void AtualizarMovimentacao(Movimentacao movimentacao)
    {
        _dados.Entry(movimentacao).State = EntityState.Modified;
        _dados.SaveChanges();
    }

    public void DeletarMovimentacao(Movimentacao movimentacao)
    {
        _dados.Movimentacao.Remove(movimentacao);
        _dados.SaveChanges();
    }

    public List<Movimentacao> ObterTodasMovimentacoes()
    {
        return _dados.Movimentacao.ToList();
    }

    public Movimentacao ObterMovimentacaoPorId(int id)
    {
        return _dados.Movimentacao.FirstOrDefault(m => m.Id == id);
    }
}