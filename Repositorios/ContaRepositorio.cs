using AdeInvest.BancoDados;
using Microsoft.EntityFrameworkCore;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Repositorios;

public class ContaRepositorio : IContaRepositorio
{
    private readonly Dados _dados;

    public ContaRepositorio(Dados dados)
    {
        _dados = dados;
    }

    public void AdicionarConta(Conta conta)
    {
        _dados.Conta.Add(conta);
        _dados.SaveChanges();
    }

    public void AtualizarConta(Conta conta)
    {
        _dados.Entry(conta).State = EntityState.Modified;
        _dados.SaveChanges();
    }

    public void DeletarConta(int id)
    {
        var conta = _dados.Conta.FirstOrDefault(p => p.Id == id);
        conta.Ativo = false;
        _dados.Conta.Update(conta);
        _dados.SaveChanges();
    }

    public List<Conta> ObterTodasContas()
    {
        return _dados.Conta.ToList();
    }

    public ContaViewModel ObterContaPorUsuarioId(int usuarioId)
    {
        var xConta = _dados.Conta
            .Include(c => c.UsuarioCliente)
            .Include(c => c.Investimento)
            .FirstOrDefault(p => p.UsuarioCliente.Id == usuarioId);

        if (xConta == null)
        {
            return null;
        }
        
        var conta = new ContaViewModel
        {
            Id = xConta.Id,
            Saldo = xConta.Saldo,
            Ativo = xConta.Ativo,
            InvestimentoId = xConta.Investimento.Id,
            CriadoDataHora = xConta.CriadoDataHora,
            InvestimentoNome = xConta.Investimento.Tipo,
            InvestimentoRendimentoEmPorcentagem = xConta.Investimento.Rendimento,
            InvestimentoResgate = xConta.Investimento.TempoResgate,
            UsuarioClienteNome = xConta.UsuarioCliente.Nome
        };

        return conta;
    }
}
