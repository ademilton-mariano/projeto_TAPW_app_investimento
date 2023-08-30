using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public interface IInvestimentoServico
{
    void AdicionarInvestimento(Investimento investimento);
    void AtualizarInvestimento(Investimento investimento);
    void DeletarInvestimento(int id);
    List<Investimento> ObterTodosInvestimentos();
    Investimento ObterInvestimentoPorId(int id);
}