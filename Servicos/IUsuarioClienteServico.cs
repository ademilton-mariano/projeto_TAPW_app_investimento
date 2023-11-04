using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public interface IUsuarioClienteServico 
{
    UsuarioCliente CadastrarUsuarioCliente(UsuarioCliente usuarioCliente);
    void AtualizarUsuarioCliente(UsuarioCliente usuarioCliente);
    void DeletarUsuarioCliente(int id);
    List<UsuarioClienteViewModel> ObterTodosUsuariosClientes();
    UsuarioClienteViewModel ObterUsuarioClientePorId(int id);
    UsuarioCliente ObterUsuarioClientePorEmail(string email);
    void AtualizarDataUltimoLogin(UsuarioCliente usuarioCliente, DateTime login);
}