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

    public void AdicionarInvestimento(Investimento investimento)
    {
        _repositorio.AdicionarInvestimento(investimento);
    }

    public void AtualizarInvestimento(Investimento investimento)
    {
        _repositorio.AtualizarInvestimento(investimento);
    }

    public void DeletarInvestimento(int id)
    {
        var investimento = _repositorio.ObterInvestimentoPorId(id);
        if (investimento != null)
        {
            _repositorio.DeletarInvestimento(investimento);
        }
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
