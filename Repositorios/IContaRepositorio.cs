using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Repositorios;

public interface IContaRepositorio
{
    void AdicionarConta(Conta conta);
    void AtualizarConta(Conta conta);
    void DeletarConta(int id);
    List<Conta> ObterTodasContas();
    ContaViewModel ObterContaPorUsuarioId(int usuarioId);
    Conta ObterContaPorId(int id);
}