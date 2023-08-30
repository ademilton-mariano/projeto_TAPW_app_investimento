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

    public void DeletarConta(Conta conta)
    {
        _dados.Conta.Remove(conta);
        _dados.SaveChanges();
    }

    public List<Conta> ObterTodasContas()
    {
        return _dados.Conta.ToList();
    }

    public Conta ObterContaPorId(int id)
    {
        return _dados.Conta.FirstOrDefault(c => c.Id == id);
    }
}
