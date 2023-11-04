using AdeInvest.Repositorios;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public class InvestimentoServico : IInvestimentoServico
{
    private readonly IInvestimentoRepositorio _repositorio;

    public InvestimentoServico(IInvestimentoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public List<Investimento> ObterTodosInvestimentos()
    {
        return _repositorio.ObterTodosInvestimentos();
    }

    public Investimento ObterInvestimentoPorId(int id)
    {
        return _repositorio.ObterInvestimentoPorId(id);
    }
}
