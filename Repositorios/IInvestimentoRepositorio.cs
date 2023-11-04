using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Repositorios;

public interface IInvestimentoRepositorio
{
    List<Investimento> ObterTodosInvestimentos();
    Investimento ObterInvestimentoPorId(int id);
}