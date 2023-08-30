using AdeInvest.Repositorios;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public class ContaServico : IContaServico
{
    private readonly IContaRepositorio _repositorio;

    public ContaServico(IContaRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public void AdicionarConta(Conta conta)
    {
        _repositorio.AdicionarConta(conta);
    }

    public void AtualizarConta(Conta conta)
    {
        _repositorio.AtualizarConta(conta);
    }

    public void DeletarConta(int id)
    {
        var conta = _repositorio.ObterContaPorId(id);
        if (conta != null)
        {
            _repositorio.DeletarConta(conta);
        }
    }

    public List<Conta> ObterTodasContas()
    {
        return _repositorio.ObterTodasContas();
    }

    public Conta ObterContaPorId(int id)
    {
        return _repositorio.ObterContaPorId(id);
    }
}
