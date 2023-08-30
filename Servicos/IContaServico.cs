using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public interface IContaServico
{
    void AdicionarConta(Conta conta);
    void AtualizarConta(Conta conta);
    void DeletarConta(int id);
    List<Conta> ObterTodasContas();
    Conta ObterContaPorId(int id);
}