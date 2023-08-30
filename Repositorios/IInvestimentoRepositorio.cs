using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Repositorios;

public interface IInvestimentoRepositorio
{
    void AdicionarInvestimento(Investimento investimento);
    void AtualizarInvestimento(Investimento investimento);
    void DeletarInvestimento(Investimento investimento);
    List<Investimento> ObterTodosInvestimentos();
    Investimento ObterInvestimentoPorId(int id);
}