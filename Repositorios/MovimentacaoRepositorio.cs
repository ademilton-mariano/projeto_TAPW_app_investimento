using AdeInvest.BancoDados;
using Microsoft.EntityFrameworkCore;


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
        var xConta = _dados.Conta.FirstOrDefault(c => c.Id == movimentacao.Id);
        if (xConta == null)
        {
            return;
        }
        var xMovimentacao = new Movimentacao
        {
            Conta = xConta,
            Tipo = movimentacao.Tipo,
            Valor = movimentacao.Valor,
            DataMovimentacao = DateTime.Now
        };

        if (xMovimentacao.Tipo == "Investimento")
        {
            xConta.Saldo += xMovimentacao.Valor;
        }
        else
        {
            xConta.Saldo -= xMovimentacao.Valor;
            xConta.Ativo = false;
        }

        _dados.Conta.Update(xConta);
        _dados.Movimentacao.Add(xMovimentacao);
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