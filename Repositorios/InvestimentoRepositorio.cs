using AdeInvest.BancoDados;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Repositorios;

public class InvestimentoRepositorio : IInvestimentoRepositorio
{
    private readonly Dados _dados;

    public InvestimentoRepositorio(Dados dados)
    {
        _dados = dados;
    }

    public List<Investimento> ObterTodosInvestimentos()
    {
        return _dados.Investimento.ToList();
    }

    public Investimento ObterInvestimentoPorId(int id)
    {
        return _dados.Investimento.FirstOrDefault(i => i.Id == id);
    }
}