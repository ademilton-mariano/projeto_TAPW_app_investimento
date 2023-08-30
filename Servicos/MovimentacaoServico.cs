using AdeInvest.Repositorios;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public class MovimentacaoServico : IMovimentacaoServico
{
    private readonly IMovimentacaoRepositorio _repositorio;

    public MovimentacaoServico(IMovimentacaoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public void AdicionarMovimentacao(Movimentacao movimentacao)
    {
        _repositorio.AdicionarMovimentacao(movimentacao);
    }

    public void AtualizarMovimentacao(Movimentacao movimentacao)
    {
        _repositorio.AtualizarMovimentacao(movimentacao);
    }

    public void DeletarMovimentacao(int id)
    {
        var movimentacao = _repositorio.ObterMovimentacaoPorId(id);
        if (movimentacao != null)
        {
            _repositorio.DeletarMovimentacao(movimentacao);
        }
    }

    public List<Movimentacao> ObterTodasMovimentacoes()
    {
        return _repositorio.ObterTodasMovimentacoes();
    }

    public Movimentacao ObterMovimentacaoPorId(int id)
    {
        return _repositorio.ObterMovimentacaoPorId(id);
    }
}