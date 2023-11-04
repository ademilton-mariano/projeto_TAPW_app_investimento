using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public interface IInvestimentoServico
{
    List<Investimento> ObterTodosInvestimentos();
    Investimento ObterInvestimentoPorId(int id);
}