using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Repositorios;
public interface IUsuarioClienteRepositorio
{
    void AdicionarUsuarioCliente(UsuarioCliente usuarioCliente);
    void AtualizarUsuarioCliente(UsuarioCliente usuarioCliente);
    void DeletarUsuarioCliente(UsuarioCliente usuarioCliente);
    List<UsuarioCliente> ObterTodosUsuariosClientes();
    UsuarioCliente ObterUsuarioClientePorId(int id);
    UsuarioCliente ObterUsuarioClientePorEmail(string email);
    void AtualizarDataUltimoLogin(UsuarioCliente usuarioCliente, DateTime login);
}