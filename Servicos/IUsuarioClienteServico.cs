using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public interface IUsuarioClienteServico 
{
    void CadastrarUsuarioCliente(UsuarioCliente usuarioCliente);
    void AtualizarUsuarioCliente(UsuarioCliente usuarioCliente);
    void DeletarUsuarioCliente(int id);
    List<UsuarioCliente> ObterTodosUsuariosClientes();
    UsuarioCliente ObterUsuarioClientePorId(int id);
    UsuarioCliente ObterUsuarioClientePorEmail(string email);
}