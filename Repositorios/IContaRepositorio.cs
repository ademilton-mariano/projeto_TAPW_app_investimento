using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Repositorios;

public interface IContaRepositorio
{
    void AdicionarConta(Conta conta);
    void AtualizarConta(Conta conta);
    void DeletarConta(Conta conta);
    List<Conta> ObterTodasContas();
    Conta ObterContaPorId(int id);
}