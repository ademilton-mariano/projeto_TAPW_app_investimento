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
            _repositorio.DeletarConta(id);
    }

    public List<Conta> ObterTodasContas()
    {
        return _repositorio.ObterTodasContas();
    }

    public ContaViewModel ObterContaPorUsuarioId(int usuarioId)
    {
        return _repositorio.ObterContaPorUsuarioId(usuarioId);
    }
}
