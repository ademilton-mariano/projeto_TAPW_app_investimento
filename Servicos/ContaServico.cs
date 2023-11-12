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

    public Conta ObterContaPorId(int id)
    {
        return _repositorio.ObterContaPorId(id);
    }

    public decimal CalcularRendimentoEAtualizarConta(Conta contaExistente, int dias)
    {
        if (dias <= 0
            || contaExistente.Investimento.TempoResgate <= 0
            || contaExistente.Investimento.Rendimento <= 0
            || contaExistente.Saldo <= 0)
        {
            return 0;
        }

        decimal rendimentoPorDia = contaExistente.Investimento.Rendimento / contaExistente.Investimento.TempoResgate;
        var rendimentoEmPorcentagem = dias * rendimentoPorDia;
        
        var rendimento = contaExistente.Saldo * (rendimentoEmPorcentagem / 100);

        if (contaExistente.DiasInvestimento < dias || contaExistente.DiasInvestimento == null)
        {
            contaExistente.Saldo += rendimento;
            contaExistente.DiasInvestimento = dias;
            _repositorio.AtualizarConta(contaExistente);
        }

        rendimento = Math.Round(rendimento, 2);

        return rendimento;
    }
}
