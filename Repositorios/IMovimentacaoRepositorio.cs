using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Repositorios;

public interface IMovimentacaoRepositorio
{
    void AdicionarMovimentacao(Movimentacao movimentacao);
    void AtualizarMovimentacao(Movimentacao movimentacao);
    void DeletarMovimentacao(Movimentacao movimentacao);
    List<Movimentacao> ObterTodasMovimentacoes();
    Movimentacao ObterMovimentacaoPorId(int id);
}