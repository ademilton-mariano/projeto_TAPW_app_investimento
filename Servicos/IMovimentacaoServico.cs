using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public interface IMovimentacaoServico
{
    void AdicionarMovimentacao(Movimentacao movimentacao);
    void DeletarMovimentacao(int id);
    List<Movimentacao> ObterTodasMovimentacoes();
    Movimentacao ObterMovimentacaoPorId(int id);
}